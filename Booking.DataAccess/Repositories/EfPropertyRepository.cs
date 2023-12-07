using Booking.DataAccess.Abstractions;
using Booking.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataAccess.Repositories
{
    public class EfPropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public EfPropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBooking(DateTime start, DateTime end, int id)
        {
            var property = _context.Properties
                .Include(property => property.Amenities)
                .Include(property => property.BookedNights)
                .FirstOrDefault(property => property.PropertyId == id);

            if (property is null)
            {
                throw new ArgumentNullException();
            }

            var isPropertyAvailable = !property.BookedNights.Any(bookedNight => bookedNight.Night >= start && bookedNight.Night < end);

            if (isPropertyAvailable == false)
            {
                throw new ArgumentException("This property already booked");
            }

            for (DateTime date = start; date < end; date = date.AddDays(1))
            {
                property.BookedNights.Add(new BookedNight() { Night = date });
            }

            _context.SaveChanges();
        }

        public void AddProperty(Property property)
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            _context.Properties.Add(property);
            _context.SaveChanges();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _context.Properties.AsNoTracking();
        }

        public IEnumerable<Property> GetAvailableProperties(DateTime start, DateTime end)
        {
            return _context.Properties
                .AsNoTracking()
                .Where(p => !p.BookedNights.Any(bookedNight => bookedNight.Night >= start && bookedNight.Night < end))
                .ToList();
        }

        public Property? GetPropertyDetails(int id)
        {
            return _context.Properties.AsNoTracking()
                .Include(property => property.Amenities)
                .Include(property => property.BookedNights)
                .FirstOrDefault(p => p.PropertyId == id);
        }
    }
}
