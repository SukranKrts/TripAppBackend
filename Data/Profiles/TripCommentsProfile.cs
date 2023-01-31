using AutoMapper;
using TripApplication.Data.DTO.TripCommentDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Data.Profiles
{
    public class TripCommentsProfile: Profile
    {
        public TripCommentsProfile()
        {
            CreateMap<TripComment, CommentInfoDTO>().ReverseMap();
            CreateMap<CommentInfoDTO, TripComment>().ReverseMap();
        }
    }
}
