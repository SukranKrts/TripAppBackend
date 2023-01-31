using AutoMapper;
using TripApplication.Data.DTO.CompanyPointDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class CompanyPoinyProfile: Profile
    {
        public CompanyPoinyProfile()
        {
            CreateMap<CompanyPoint, PointInfoDTO>()
                .ReverseMap();
            CreateMap<PointInfoDTO, CompanyPoint>()
                .ReverseMap();
        }
    }
}
