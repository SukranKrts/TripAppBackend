using AutoMapper;
using TripApplication.Data.DTO.BasketDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class BasketProfile: Profile
    {
        public BasketProfile() {
            CreateMap<Basket, BasketInfoDTO>().ReverseMap();
            CreateMap<BasketInfoDTO, Basket>().ReverseMap();
        }
    }
}
