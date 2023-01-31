using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.TripCommentDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class TripCommentsService
    {
        private MainDb context;
        private IMapper mapper;

        public TripCommentsService(MainDb _context, IMapper _mapper) {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<Result<TripComment>> CreateComment(CommentInfoDTO comment)
        {
            try
            {
                TripComment _comment = mapper.Map<TripComment>(comment);
                context.TripComments.Add(_comment);
                await context.SaveChangesAsync();
                return Result<TripComment>.PrepareSuccess(_comment);

            }catch(Exception ex) { return Result<TripComment>.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result<List<CommentInfoDTO>>> GetCommnet()
        {
            try
            {
                var _comment = await context.TripComments
                    .Select(x => mapper.Map<CommentInfoDTO>(x)).ToListAsync();
                return Result<List<CommentInfoDTO>>.PrepareSuccess(_comment);
            }catch(Exception ex) { return Result<List<CommentInfoDTO>>.PrepareFailure(ex.ToString()); }
        }
    }
}
