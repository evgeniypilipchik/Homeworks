using CarMarket.Data;
using CarMarket.Data.Models;
using CarMarket.Models.Listing;
using CarMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CarMarket.Services
{
    public class ListingService : IListingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ListingService(
            ApplicationDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<List<ListingsViewModel>> GetAllListingsAsync(int? minPrice, int? maxPrice, string? excludeUserId, CancellationToken cancellationToken)
        {
            var query = _context.Listings.AsQueryable();

            if (minPrice.HasValue)
                query = query.Where(l => l.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(l => l.Price <= maxPrice.Value);

            if (!string.IsNullOrEmpty(excludeUserId))
                query = query.Where(l => l.ApplicationUserId != excludeUserId);

            var listings = await query.ToListAsync(cancellationToken);

            return listings.Select(l => new ListingsViewModel
            {
                Id = l.Id,
                Brand = l.Brand,
                Model = l.Model,
                Year = l.Year,
                MileAge = l.MileAge,
                Price = l.Price
            }).ToList();
        }

        public async Task<DetailsViewModel> GetListingDetailsAsync(int id, string? currentUserId, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings
                .Include(l => l.ApplicationUser)
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

            if (listing == null) return null;

            bool isFavorite = false;
            if (!string.IsNullOrEmpty(currentUserId))
            {
                isFavorite = await _context.FavoriteListings
                    .AnyAsync(fl => fl.ApplicationUserId == currentUserId && fl.ListingId == id, cancellationToken);
            }

            return MapToDetailsViewModel(listing, isFavorite);
        }

        public async Task<DetailsViewModel> GetUserListingDetailsAsync(int id, string userId, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings
                .Include(l => l.ApplicationUser)
                .FirstOrDefaultAsync(l => l.Id == id && l.ApplicationUserId == userId, cancellationToken);

            if (listing == null) return null;

            bool isFavorite = await _context.FavoriteListings
                .AnyAsync(fl => fl.ApplicationUserId == userId && fl.ListingId == id, cancellationToken);

            return MapToDetailsViewModel(listing, isFavorite);
        }

        public async Task CreateListingAsync(CreateViewModel model, string userId, CancellationToken cancellationToken)
        {
            var listing = new Listing
            {
                Vin = model.Vin,
                Brand = model.Brand,
                Model = model.Model,
                Year = model.Year,
                Generation = model.Generation,
                Type = model.Type,
                DriveType = model.DriveType,
                FuelType = model.FuelType,
                EngineVolume = model.EngineVolume,
                GearType = model.GearType,
                Color = model.Color,
                IsRegistrated = model.IsRegistrated,
                IsCrashed = model.IsCrashed,
                IsPledged = model.IsPledged,
                MileAge = model.MileAge,
                Price = model.Price,
                ApplicationUserId = userId
            };

            await _context.Listings.AddAsync(listing, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateListingAsync(int id, CreateViewModel model, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings.FindAsync(new object[] { id }, cancellationToken);
            if (listing == null) return;

            listing.Vin = model.Vin;
            listing.Brand = model.Brand;
            listing.Model = model.Model;
            listing.Year = model.Year;
            listing.Generation = model.Generation;
            listing.Type = model.Type;
            listing.DriveType = model.DriveType;
            listing.FuelType = model.FuelType;
            listing.EngineVolume = model.EngineVolume;
            listing.GearType = model.GearType;
            listing.Color = model.Color;
            listing.IsRegistrated = model.IsRegistrated;
            listing.IsCrashed = model.IsCrashed;
            listing.IsPledged = model.IsPledged;
            listing.MileAge = model.MileAge;
            listing.Price = model.Price;

            _context.Listings.Update(listing);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteListingAsync(int id, string userId, CancellationToken cancellationToken)
        {
            var listing = await _context.Listings
                .FirstOrDefaultAsync(l => l.ApplicationUserId == userId && l.Id == id, cancellationToken);

            if (listing != null)
            {
                _context.Listings.Remove(listing);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<ListingsViewModel>> GetUserListingsAsync(string userId, CancellationToken cancellationToken)
        {
            var listings = await _context.Listings
                .Where(l => l.ApplicationUserId == userId)
                .ToListAsync(cancellationToken);

            return listings.Select(l => new ListingsViewModel
            {
                Id = l.Id,
                Brand = l.Brand,
                Model = l.Model,
                Year = l.Year,
                MileAge = l.MileAge,
                Price = l.Price
            }).ToList();
        }

        public async Task<List<ListingsViewModel>> GetUserFavoritesAsync(string userId, CancellationToken cancellationToken)
        {
            var favorites = await _context.FavoriteListings
                .Where(fl => fl.ApplicationUserId == userId)
                .Include(fl => fl.Listing)
                .Select(fl => fl.Listing)
                .ToListAsync(cancellationToken);

            return favorites.Select(l => new ListingsViewModel
            {
                Id = l.Id,
                Brand = l.Brand,
                Model = l.Model,
                Year = l.Year,
                MileAge = l.MileAge,
                Price = l.Price,
                IsFavorite = true
            }).ToList();
        }

        public async Task AddToFavoritesAsync(string userId, int listingId, CancellationToken cancellationToken)
        {
            _context.FavoriteListings.Add(new FavoriteListing
            {
                ApplicationUserId = userId,
                ListingId = listingId,
            });
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveFromFavoritesAsync(string userId, int listingId, CancellationToken cancellationToken)
        {
            var favorite = await _context.FavoriteListings
                .FirstOrDefaultAsync(fl => fl.ApplicationUserId == userId && fl.ListingId == listingId, cancellationToken);

            if (favorite != null)
            {
                _context.FavoriteListings.Remove(favorite);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<VerificationViewModel> VerifyListingAsync(string vin, int listingId, CancellationToken cancellationToken)
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "ExternalData", "ExternalData.json");

            if (!File.Exists(filePath))
            {
                return null;
            }

            var jsonData = await File.ReadAllTextAsync(filePath, cancellationToken);
            var externalData = JsonSerializer.Deserialize<List<VerificationViewModel>>(jsonData);
            return externalData.FirstOrDefault(c => c.Vin == vin);
        }

        private DetailsViewModel MapToDetailsViewModel(Listing listing, bool isFavorite)
        {
            return new DetailsViewModel
            {
                Id = listing.Id,
                Vin = listing.Vin,
                Brand = listing.Brand,
                Model = listing.Model,
                Year = listing.Year,
                Generation = listing.Generation,
                Type = listing.Type,
                DriveType = listing.DriveType,
                FuelType = listing.FuelType,
                EngineVolume = listing.EngineVolume,
                GearType = listing.GearType,
                Color = listing.Color,
                IsRegistrated = listing.IsRegistrated,
                IsCrashed = listing.IsCrashed,
                IsPledged = listing.IsPledged,
                MileAge = listing.MileAge,
                Price = listing.Price,
                UserName = listing.ApplicationUser.UserName.Split('@')[0],
                Email = listing.ApplicationUser.Email,
                PhoneNumber = listing.ApplicationUser.PhoneNumber,
                IsFavorite = isFavorite
            };
        }
    }
}