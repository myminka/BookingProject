using Bogus;
using Booking.DataAccess.Abstractions;
using Booking.DataAccess.Entities;

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
                .Where(p => !p.BookedNights.Any(bookedNight => bookedNight.Night >= start && bookedNight.Night < end))
                .ToList();

            return availableProperties;
        }

        public Property? GetPropertyDetails(int id)
        {
            return properties.FirstOrDefault(p => p.PropertyId == id);
        }

        public void AddBooking(DateTime start, DateTime end, int id)
        {
            var property = GetPropertyDetails(id);

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
                property.BookedNights.Add(new BookedNight() { Night = date});
            }
        }

        private static List<Property> GenerateFakeData(int count)
        {
            //var faker = new Faker<Property>()
            //    .RuleFor(p => p.PropertyId, f => f.IndexFaker)
            //    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            //    .RuleFor(p => p.Blurb, f => f.Lorem.Sentence())
            //    .RuleFor(p => p.Location, f => f.Address.City())
            //    .RuleFor(p => p.NumberOfBedrooms, f => f.Random.Int(1, 5))
            //    .RuleFor(p => p.CostPerNight, f => f.Random.Decimal(50, 300))
            //    .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            //    .RuleFor(p => p.Amenities, f => f.Make(f.Random.Number(1, 5), () => f.Commerce.Product()))
            //    .RuleFor(p => p.BookedNights, f => f.Make(f.Random.Number(10, 40), () => new BookedNight() { Night = f.Date.Future() }));

            //return faker.Generate(count);

            return new List<Property>();
        }
    }
}
