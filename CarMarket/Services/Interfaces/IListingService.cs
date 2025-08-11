using CarMarket.Models.Listing;

namespace CarMarket.Services.Interfaces
{
    public interface IListingService
    {
        Task<List<ListingsViewModel>> GetAllListingsAsync(int? minPrice, int? maxPrice, string? excludeUserId, CancellationToken cancellationToken);
        Task<DetailsViewModel> GetListingDetailsAsync(int id, string? currentUserId, CancellationToken cancellationToken);
        Task<DetailsViewModel> GetUserListingDetailsAsync(int id, string userId, CancellationToken cancellationToken);
        Task CreateListingAsync(CreateViewModel model, string userId, CancellationToken cancellationToken);
        Task UpdateListingAsync(int id, CreateViewModel model, CancellationToken cancellationToken);
        Task DeleteListingAsync(int id, string userId, CancellationToken cancellationToken);
        Task<List<ListingsViewModel>> GetUserListingsAsync(string userId, CancellationToken cancellationToken);
        Task<List<ListingsViewModel>> GetUserFavoritesAsync(string userId, CancellationToken cancellationToken);
        Task AddToFavoritesAsync(string userId, int listingId, CancellationToken cancellationToken);
        Task RemoveFromFavoritesAsync(string userId, int listingId, CancellationToken cancellationToken);
        Task<VerificationViewModel> VerifyListingAsync(string vin, int listingId, CancellationToken cancellationToken);
    }
}