using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class TripService
    {
        private MainDb context;
        private IMapper mapper;

        public TripService(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task<Result<Trip>> CreateTrip(CreateTripDTO trip)
        {
            if(IsTripNameExist(trip.TripName))
            {
                throw new Exception("The Trip already exist!");
            }

            try
            {
                Trip _trip = mapper.Map<Trip>(trip);
                context.Trips.Add(_trip);
                await context.SaveChangesAsync();
                return Result<Trip>.PrepareSuccess(_trip);

            }catch(Exception e) 
            { return Result<Trip>.PrepareFailure(e.ToString());}
        }

        public async Task<Result<Trip>> UpdateTrip(TripInfoDTO trip)
        {
            if(!IsTripExist(trip.Id))
            {
                throw new Exception("Trip not found!");
            }

            try
            {
                var _trip = mapper.Map<Trip>(trip);
                context.Trips.Update(_trip);
                await context.SaveChangesAsync();
                return Result<Trip>.PrepareSuccess(_trip);

            }catch(Exception e) 
            { return Result<Trip>.PrepareFailure(e.ToString()); }
        }

        public async Task<Result> DeleteTrip(int id)
        {
            try
            {
                var _trip = await context.Trips
                    .FirstOrDefaultAsync(x => x.Id == id);
                context.Trips.Remove(_trip);
                context.SaveChanges();
                return Result.PrepareSuccess();

            }
            catch(Exception e) 
            { return Result<Trip>.PrepareFailure(e.ToString()); }
        }

        public async Task<Result<List<TripListDTO>>> GetTripList()
        {
            try
            {
                var trip = await context.Trips
                    .Select(x => mapper.Map<TripListDTO>(x)).ToListAsync();
                return Result<List<TripListDTO>>.PrepareSuccess(trip);

            }catch(Exception e) 
            {return Result<List<TripListDTO>>.PrepareFailure(e.ToString());}
        }

        public async Task<Result<List<TripInfoDTO>>> GetTripById(int id)
        {
            if (!IsTripExist(id))
            {
                throw new Exception("Trip not found!");
            }

            try
            {
                var _trip = await context.Trips
                    .Where(x => x.Id == id)
                    .Select(x => mapper.Map<TripInfoDTO>(x))
                    .ToListAsync();
                return Result<List<TripInfoDTO>>.PrepareSuccess(_trip);

            }catch(Exception e) 
            {return Result<List<TripInfoDTO>>.PrepareFailure(e.ToString());}
        }

        public async Task<Result<List<TripListDTO>>> SearchTrip(String search)
        {
            try
            {
                var trip = new List<Trip>();
                if (!string.IsNullOrEmpty(search))
                {
                    trip = await (from Trip in context.Trips
                                  where Trip.TripType.Contains(search) || 
                                  Trip.TripName.Contains(search)    
                                  select Trip
                                  ).ToListAsync();
                }
                var _trip = mapper.Map<List<TripListDTO>>(trip);
                return Result<List<TripListDTO>>.PrepareSuccess(_trip);

            }catch(Exception e) 
            {return Result<List<TripListDTO>>.PrepareFailure(e.ToString());}
        }

        //////////////////////////////////////////////////
        
        private bool IsTripNameExist(string name)
        {
            return context.Trips.Any(x =>x.TripName == name);
        }

        private bool IsTripExist(int id)
        {
            return context.Trips.Any(x => x.Id == id);
        }
    }
}
