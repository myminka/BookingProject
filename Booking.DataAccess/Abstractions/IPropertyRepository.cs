using Booking.DataAccess.Entities;

namespace Booking.DataAccess.Abstractions
{
    public interface IPropertyRepository
    {
        public IEnumerable<Property> GetAllProperties();
        public IEnumerable<Property> GetAvailableProperties(DateTime start, DateTime end);
        public Property? GetPropertyDetails(int id);
        public void AddProperty(Property property);
        public void AddBooking(DateTime start, DateTime end, int id);
    }
}
