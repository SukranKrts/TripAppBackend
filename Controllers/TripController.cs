using Microsoft.AspNetCore.Mvc;
using TripApplication.Common;
using TripApplication.Data.DTO.TripDTO;
using TripApplication.Data.Entities;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController: ControllerBase
    {
        private readonly TripService _tripService;

        public TripController(TripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost]
        [Route("CreateTrip")]
        public async Task<IActionResult> CreateTrip([FromBody] CreateTripDTO trip)
        {
            return Ok(await _tripService.CreateTrip(trip));
        }

        [HttpPut]
        [Route("UpdateTrip")]
        public async Task<IActionResult> UpdateTrip([FromBody] TripInfoDTO trip)
        {
            return Ok(await _tripService.UpdateTrip(trip));
        }

        [HttpDelete]
        [Route("DeleteTrip")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            return Ok(await _tripService.DeleteTrip(id));
        }

        [HttpGet]
        [Route("List/{id}")]
        public async Task<Result<List<TripInfoDTO>>> GetTripById(int id)
        {
            return await _tripService.GetTripById(id);
        }

        [HttpGet]
        [Route("List")]
        public async Task<Result<List<TripListDTO>>> GetTripList()
        {
            return await _tripService.GetTripList();
        }

        [HttpGet]
        [Route("CategoryList")]
        public async Task<Result<List<TripListDTO>>> GetSearchTrip(String search)
        {
            return await _tripService.SearchTrip(search);
        }
    }
}
