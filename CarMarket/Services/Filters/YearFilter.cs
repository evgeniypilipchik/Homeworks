using CarMarket.Data.Models;
using CarMarket.Services.Interfaces;

namespace CarMarket.Services.Filters
{
    public class YearFilter : IListingFilter
    {
        private readonly int? _minYear;
        private readonly int? _maxYear;

        public YearFilter(int? minYear, int? maxYear)
        {
            _minYear = minYear;
            _maxYear = maxYear;
        }

        public IQueryable<Listing> Apply(IQueryable<Listing> query)
        {
            if (_minYear.HasValue)
                query = query.Where(l => l.Year >= _minYear.Value);

            if (_maxYear.HasValue)
                query = query.Where(l => l.Year <= _maxYear.Value);

            return query;
        }
    }
}
