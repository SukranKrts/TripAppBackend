using AutoMapper;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class TripProfile: Profile
    {
        public TripProfile() {
            CreateMap<Trip, TripInfoDTO>().ReverseMap();
            CreateMap<TripInfoDTO, Trip>().ReverseMap();
            CreateMap<Trip, TripListDTO>().ReverseMap();
            CreateMap<TripListDTO, Trip>().ReverseMap();
            CreateMap<Trip, CreateTripDTO>().ReverseMap();
            CreateMap<CreateTripDTO, Trip>().ReverseMap();
            CreateMap<Trip, TripGetById>().ReverseMap();
            CreateMap<TripGetById, Trip>().ReverseMap();
        }
    }
}
