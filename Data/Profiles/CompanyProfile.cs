using AutoMapper;
using TripApplication.Data.DTO.CompanyDTO;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile() {
            CreateMap<Company, CompanyCreateDTO>().ReverseMap();
            CreateMap<CompanyCreateDTO, Company>().ReverseMap();
            CreateMap<CompanyUpdateDTO, Company>().ReverseMap();
            CreateMap<Company, CompanyUpdateDTO>().ReverseMap();
            CreateMap<Company, CompanyInfoDTO>().ReverseMap();
            CreateMap<CompanyInfoDTO, Company>().ReverseMap();
        }
    }
}
