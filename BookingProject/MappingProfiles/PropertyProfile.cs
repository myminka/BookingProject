using AutoMapper;
using Booking.DataAccess.Entities;
using BookingProject.Models;

namespace BookingProject.MappingProfiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, ViewPropertyDetails>()
                .ForMember(property => property.Id, opt => opt.MapFrom(src => src.PropertyId))
                .ReverseMap();

            CreateMap<Property, PropertyListingViewModel>()
                .ForMember(property => property.Id, opt => opt.MapFrom(src => src.PropertyId));

            CreateMap<PropertyDetailsModel, Property>()
                .ForMember(property => property.Amenities, opt => opt.Ignore())
                .ForMember(property => property.BookedNights, opt => opt.Ignore())
                .ForMember(property => property.PropertyId, opt => opt.Ignore());
        }
    }
}
