using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.FavouriteDTO;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class FavouriteService
    {
        private MainDb context;
        private IMapper mapper;

        public FavouriteService(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Result<Favourite>> CreateFavourite(FavouriteInfoDTO favourite)
        {
            try
            {
                Favourite _favourite = mapper.Map<Favourite>(favourite);
                context.Favourites.Add(_favourite);
                await context.SaveChangesAsync();
                return Result<Favourite>.PrepareSuccess(_favourite);

            }catch(Exception ex) 
            { return Result<Favourite>.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result<List<FavouriteInfoDTO>>> GetFavourite()
        {
            try
            {
                var favourite = await context.Favourites
                    .Select(x => mapper.Map<FavouriteInfoDTO>(x))
                    .ToListAsync();
                return Result<List<FavouriteInfoDTO>>
                    .PrepareSuccess(favourite);

            }
            catch (Exception ex) 
            { return Result<List<FavouriteInfoDTO>>
                    .PrepareFailure(ex.ToString()); }
        }

        public async Task<Result> DeleteFavourite(int id)
        {

            try
            {
                var favourite = await context.Favourites
                    .FirstOrDefaultAsync(x => x.Id == id);
                context.Favourites.Remove(favourite);
                await context.SaveChangesAsync();
                return Result.PrepareSuccess();

            }catch(Exception ex) 
            { return Result.PrepareFailure(ex.ToString());}
        }

        public async Task<Result<List<TripListDTO>>> GetFavoriteById(int id)
        {
            try
            {
                var trip = await (from f in context.Favourites
                                      join t in context.Trips 
                                      on f.TripId equals t.Id
                                      where f.UserId== id
                                      select mapper.Map<TripListDTO>(t))
                                      .ToListAsync();
                
                return Result<List<TripListDTO>>.PrepareSuccess(trip);
            }
            catch(Exception ex)
            {return Result<List<TripListDTO>>.PrepareFailure(ex.ToString());}
        }
    }
}
