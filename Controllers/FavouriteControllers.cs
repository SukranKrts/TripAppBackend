using Microsoft.AspNetCore.Mvc;
using TripApplication.Common;
using TripApplication.Data.DTO.FavouriteDTO;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    public class FavouriteControllers: ControllerBase
    {
        private readonly FavouriteService _favourite;
        
        public FavouriteControllers(FavouriteService favourite)
        {
            _favourite = favourite;
        }

        [HttpPost]
        [Route("CreateFavourite")]
        public async Task<IActionResult> CreateFavourite([FromBody] FavouriteInfoDTO favourite)
        {
            return Ok(await _favourite.CreateFavourite(favourite));
        }

        [HttpDelete]
        [Route("DeleteFavourite")]
        public async Task<IActionResult> DeleteFavourite(int id)
        {
            return Ok(await _favourite.DeleteFavourite(id));
        }

        [HttpGet]
        [Route("GetByIdWithTrip")]
        public async Task<Result<List<TripListDTO>>> GetFavouriteById(int id)
        {
            return await _favourite.GetFavoriteById(id);
        }

        [HttpGet]
        [Route("GetFavourite")]
        public async Task<Result<List<FavouriteInfoDTO>>> GetFavourite()
        {
            return await _favourite.GetFavourite();
        }
    }
}
