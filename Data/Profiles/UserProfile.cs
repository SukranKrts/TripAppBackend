using AutoMapper;
using TripApplication.Data.DTO.UserDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() { 
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, UserSignIn>().ReverseMap();
            CreateMap<UserSignIn,User>().ReverseMap();
            CreateMap<User, UserInfoDTO>().ReverseMap();
            CreateMap<UserInfoDTO, User>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, User>().ReverseMap();
        }
    }
}
