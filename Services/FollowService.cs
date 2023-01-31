using AutoMapper;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.FollowDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class FollowService
    {
        private MainDb context;
        private IMapper mapper;

        public FollowService(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Result<Follow>> CreateFollow(FollowInfoDTO follow)
        {
            try
            {
                Follow _follow = mapper.Map<Follow>(follow);
                context.Follows.Add(_follow);
                await context.SaveChangesAsync();
                return Result<Follow>.PrepareSuccess(_follow);

            }
            catch (Exception ex) 
            {return Result<Follow>.PrepareFailure(ex.ToString());}
        }
    }
}
