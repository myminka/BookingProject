using Bogus;
using Booking.DataAccess.Abstractions;
using Booking.DataAccess.Entities;
using Nest;

namespace Booking.DataAccess.Repositories
{
    public class DummyPropertyRepository : IPropertyRepository
    {
        private static List<Property> properties = new();

        public DummyPropertyRepository()
        {
            properties = GenerateFakeData(50);
        }

        public void AddProperty(Property property)
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            properties.Add(property);
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return properties;
        }

        public IEnumerable<Property> GetAvailableProperties(DateTime start, DateTime end)
        {
            var availableProperties = properties
                .Where(p => !p.BookedDates.Any(date => date >= start && date <= end))
                .ToList();

            return availableProperties;
        }

        public Property? GetPropertyDetails(int id)
        {
            return properties.FirstOrDefault(p => p.Id == id);
        }

        public void AddBooking(DateTime start, DateTime end, int id)
        {
            var property = GetPropertyDetails(id);

            if (property is null)
            {
                throw new ArgumentNullException();
            }

            for (DateTime date = start; date < end; date = date.AddDays(1))
            {
                property.BookedDates.Add(date);
            }
        }

        private static List<Property> GenerateFakeData(int count)
        {
            var faker = new Faker<Property>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Blurb, f => f.Lorem.Sentence())
                .RuleFor(p => p.Location, f => f.Address.City())
                .RuleFor(p => p.NumberOfBedrooms, f => f.Random.Int(1, 5))
                .RuleFor(p => p.CostPerNight, f => f.Random.Decimal(50, 300))
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Amenities, f => f.Make(f.Random.Number(1, 5), () => f.Commerce.Product()))
                .RuleFor(p => p.BookedDates, f => f.Make(f.Random.Number(5, 20), () => f.Date.Future()));

            return faker.Generate(count);
        }
    }
}
