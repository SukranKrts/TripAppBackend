using AutoMapper;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.CompanyPointDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class CompanyPointService
    {
        private MainDb context;
        private IMapper mapper;

        public CompanyPointService(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Result<CompanyPoint>> CreatePoint(PointInfoDTO point)
        {
            try
            {
                CompanyPoint _point = mapper.Map<CompanyPoint>(point);
                context.CompanyPoints.Add(_point);
                await context.SaveChangesAsync();
                return Result<CompanyPoint>.PrepareSuccess(_point);

            }
            catch (Exception ex) { return Result<CompanyPoint>.PrepareFailure(ex.ToString()); }
        }
    }
}
