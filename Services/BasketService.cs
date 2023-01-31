using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TripApplication.Common;
using TripApplication.Data;
using TripApplication.Data.DTO.BasketDTO;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;

namespace TripApplication.Services
{
    public class BasketService
    {
        private MainDb context;
        private IMapper mapper;

        public BasketService(MainDb context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Result<Basket>> CreateBasket(BasketInfoDTO basket)
        {
            try
            {
                Basket _basket = mapper.Map<Basket>(basket);
                context.Baskets.Add(_basket);
                await context.SaveChangesAsync();
                return Result<Basket>.PrepareSuccess(_basket);
            }
            catch (Exception ex) 
            { return Result<Basket>.PrepareFailure(ex.ToString()); }
        }

        public async Task<Result> DeleteBasket(int id)
        {
            try
            {
                var basket = await context.Baskets
                    .FirstOrDefaultAsync(x => x.Id == id);
                context.Baskets.Remove(basket);
                await context.SaveChangesAsync();
                return Result.PrepareSuccess();

            }
            catch (Exception ex) 
            { return Result.PrepareFailure(ex.ToString()); }
        }
        public async Task<Result<List<TripListDTO>>> GetBasketById(int id)
        {
            try
            {
                var basket = await (from b in context.Baskets
                                    join t in context.Trips 
                                    on b.TripId equals t.Id
                                    where b.UserId == id
                                    select mapper.Map<TripListDTO>(t))
                                    .ToListAsync();
                return Result<List<TripListDTO>>.PrepareSuccess(basket);

            }
            catch (Exception ex) 
            {return Result<List<TripListDTO>>.PrepareFailure(ex.ToString());}
        }

        public async Task<Result<List<Basket>>> GetBasket()
        {
            try
            {
                var basket = await context.Baskets
                    .Select(x => mapper.Map<Basket>(x)).ToListAsync();
                return Result<List<Basket>>.PrepareSuccess(basket);

            }catch(Exception ex) 
            {return Result<List<Basket>>.PrepareFailure(ex.ToString());}
        }
    }
}
