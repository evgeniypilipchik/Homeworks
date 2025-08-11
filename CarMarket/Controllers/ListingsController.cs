using CarMarket.Models.Listing;
using CarMarket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarMarket.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingService _listingService;
        private readonly ILogger<ListingsController> _logger;

        public ListingsController(
            IListingService listingService,
            ILogger<ListingsController> logger)
        {
            _listingService = listingService;
            _logger = logger;
        }

        public async Task<IActionResult> Listings(int? minPrice = null, int? maxPrice = null, CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var viewListings = await _listingService.GetAllListingsAsync(minPrice, maxPrice, userId, cancellationToken);

                ViewBag.MinPrice = minPrice;
                ViewBag.MaxPrice = maxPrice;
                return View(viewListings);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Listings request was canceled");
                return BadRequest("Listings request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading listings: {ex}");
                return StatusCode(500, "Error loading listings");
            }
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel newListing, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newListing);
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _listingService.CreateListingAsync(newListing, userId, cancellationToken);
                return RedirectToAction("MyListings");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Create listing request was canceled");
                return BadRequest("Create listing request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating listing: {ex}");
                return StatusCode(500, "Error creating listing");
            }
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var listingDetails = await _listingService.GetListingDetailsAsync(id, userId, cancellationToken);

                if (listingDetails == null)
                {
                    return NotFound();
                }

                return View(listingDetails);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Details request was canceled");
                return BadRequest("Details request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading listing details: {ex}");
                return StatusCode(500, "Error loading listing details");
            }
        }

        public async Task<IActionResult> Verification(string vin, int listingId, CancellationToken cancellationToken = default)
        {
            try
            {
                ViewBag.ListingId = listingId;
                var car = await _listingService.VerifyListingAsync(vin, listingId, cancellationToken);

                if (car == null)
                {
                    return NotFound("The car is missing from the database");
                }

                return View(car);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Verification request was canceled");
                return BadRequest("Verification request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error verifying: {ex}");
                return StatusCode(500, "Error verifying");
            }
        }

        [Authorize]
        public async Task<IActionResult> MyListings(CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userListings = await _listingService.GetUserListingsAsync(userId, cancellationToken);
                return View(userListings);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("MyListings request was canceled");
                return BadRequest("MyListings request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading user listings: {ex}");
                return StatusCode(500, "Error loading user listings");
            }
        }

        [Authorize]
        public async Task<IActionResult> MyListingDetails(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var listingDetails = await _listingService.GetUserListingDetailsAsync(id, userId, cancellationToken);

                if (listingDetails == null)
                {
                    return NotFound();
                }

                return View(listingDetails);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Details request was canceled");
                return BadRequest("Details request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading listing details: {ex}");
                return StatusCode(500, $"Error loading listing details");
            }
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _listingService.DeleteListingAsync(id, userId, cancellationToken);
                return RedirectToAction("MyListings");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Removing listing was canceled");
                return BadRequest("Removing listing was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing listing: {ex}");
                return StatusCode(500, "Error removing listing");
            }
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            try
            {
                var listing = await _listingService.GetListingDetailsAsync(id, null, cancellationToken);
                if (listing == null)
                {
                    return NotFound();
                }

                return View(new CreateViewModel
                {
                    Id = id,
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
                    Price = listing.Price
                });
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Updating listing was canceled");
                return BadRequest("Updating listing was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading listing for updating: {ex}");
                return StatusCode(500, "Error loading listing for updating");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateViewModel editedListing, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(editedListing);
                }

                await _listingService.UpdateListingAsync(id, editedListing, cancellationToken);
                return RedirectToAction("MyListings");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Updating listing was canceled");
                return BadRequest("Updating listing was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating listing: {ex}");
                return StatusCode(500, "Error updating listing");
            }
        }

        [Authorize]
        public async Task<IActionResult> Favorites(CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var favorites = await _listingService.GetUserFavoritesAsync(userId, cancellationToken);
                return View(favorites);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Favorite listings request was canceled");
                return BadRequest("Favorites listings request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading favorite listings: {ex}");
                return StatusCode(500, "Error loading favorite listing");
            }
        }

        [Authorize]
        public async Task<IActionResult> AddToFavorites(int listingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _listingService.AddToFavoritesAsync(userId, listingId, cancellationToken);
                return RedirectToAction("Favorites");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Adding to favorites request was canceled");
                return BadRequest("Adding to favorites request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding to favorites: {ex}");
                return StatusCode(500, "Error adding to favorites");
            }
        }

        [Authorize]
        public async Task<IActionResult> RemoveFromFavorites(int listingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _listingService.RemoveFromFavoritesAsync(userId, listingId, cancellationToken);
                return RedirectToAction("Favorites");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Remove from favorites request was canceled");
                return BadRequest("Remove from favorites request was canceled");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error removing listing from favorites: {ex}");
                return StatusCode(500, "Error removing from favorites");
            }
        }
    }
}