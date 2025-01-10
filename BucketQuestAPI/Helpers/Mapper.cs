
using AutoMapper;
using BucketQuestAPI.DTOs;
using BucketQuestAPI.Entities;

namespace CafeLinkAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TripPackage, PackageResponseDto>()
                .ForMember(dest => dest.PricePerPerson, opt => opt.MapFrom(src => src.Trips.Sum(t => t.Price)));
        }
    }
}