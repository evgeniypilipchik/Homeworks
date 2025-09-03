using CarMarket.Data.Models;
using CarMarket.Services.Interfaces;

namespace CarMarket.Services.Filters
{
    public class ExcludeUserFilter : IListingFilter
    {
        private readonly string? _excludeUserId;

        public ExcludeUserFilter(string? excludeUserId)
        {
            _excludeUserId = excludeUserId;
        }

        public IQueryable<Listing> Apply(IQueryable<Listing> query)
        {
            if (!string.IsNullOrEmpty(_excludeUserId))
                query = query.Where(l => l.ApplicationUserId != _excludeUserId);

            return query;
        }
    }
}
