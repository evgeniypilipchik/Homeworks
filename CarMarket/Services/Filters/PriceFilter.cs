using CarMarket.Data.Models;
using CarMarket.Services.Interfaces;

namespace CarMarket.Services.Filters
{
    public class PriceFilter : IListingFilter
    {
        private readonly int? _minPrice;
        private readonly int? _maxPrice;

        public PriceFilter(int? minPrice, int? maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        public IQueryable<Listing> Apply(IQueryable<Listing> query)
        {
            if (_minPrice.HasValue)
                query = query.Where(l => l.Price >= _minPrice.Value);

            if (_maxPrice.HasValue)
                query = query.Where(l => l.Price <= _maxPrice.Value);

            return query;
        }
    }
}