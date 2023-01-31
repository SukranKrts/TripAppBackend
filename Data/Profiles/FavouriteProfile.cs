using AutoMapper;
using TripApplication.Data.DTO.FavouriteDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class FavouriteProfile: Profile
    {
        public FavouriteProfile()
        {
            CreateMap<Favourite, FavouriteInfoDTO>().ReverseMap();
            CreateMap<FavouriteInfoDTO, Favourite>().ReverseMap();
            CreateMap<Favourite, GetFavouriteDTO>().ReverseMap();
            CreateMap<GetFavouriteDTO, Favourite>().ReverseMap();
        }
    }
}
