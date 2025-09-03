using CarMarket.Data.Models;
using CarMarket.Services.Interfaces;

namespace CarMarket.Services.Filters
{
    public class MileageFilter : IListingFilter
    {
        private readonly int? _minMileage;
        private readonly int? _maxMileage;

        public MileageFilter(int? minMileage, int? maxMileage)
        {
            _minMileage = minMileage;
            _maxMileage = maxMileage;
        }

        public IQueryable<Listing> Apply(IQueryable<Listing> query)
        {
            if (_minMileage.HasValue)
                query = query.Where(l => l.Mileage >= _minMileage.Value);

            if (_maxMileage.HasValue)
                query = query.Where(l => l.Mileage <= _maxMileage.Value);

            return query;
        }
    }
}