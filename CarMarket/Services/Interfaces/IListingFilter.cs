using CarMarket.Data.Models;

namespace CarMarket.Services.Interfaces
{
    public interface IListingFilter
    {
        IQueryable<Listing> Apply(IQueryable<Listing> query);
    }
}
