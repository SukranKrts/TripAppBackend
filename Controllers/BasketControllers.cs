using Microsoft.AspNetCore.Mvc;
using TripApplication.Common;
using TripApplication.Data.DTO.BasketDTO;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    public class BasketControllers: ControllerBase
    {
        private readonly BasketService _basket;

        public BasketControllers(BasketService basket)
        {
            _basket = basket;
        }

        [HttpPost]
        [Route("CreateBasket")]
        public async Task<IActionResult> CreateBasket([FromBody] BasketInfoDTO basket)
        {
            return Ok(await _basket.CreateBasket(basket));
        }

        [HttpDelete]
        [Route("DeleteBasket")]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            return Ok(await (_basket.DeleteBasket(id)));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Result<List<TripListDTO>>> GetBasketById(int id)
        {
            return await _basket.GetBasketById(id);
        }

        [HttpGet]
        [Route("GetBasket")]
        public async Task<Result<List<Basket>>> GetBasket()
        {
            return await _basket.GetBasket();
        }
    }
}
