using AutoMapper;
using TripApplication.Data.DTO.FollowDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class FollowProfile: Profile
    {
        public FollowProfile() 
        {
            CreateMap<Follow, FollowInfoDTO>().ReverseMap();
            CreateMap<FollowInfoDTO,Follow>().ReverseMap();
        }
    }
}
