using Microsoft.AspNetCore.Mvc;
using TripApplication.Data.DTO.CompanyPointDTO;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    public class CompanyPointControllers: ControllerBase
    {
        private readonly CompanyPointService _point;
        
        public CompanyPointControllers(CompanyPointService point)
        {
            _point = point;
        }

        [HttpPost]
        [Route("CreatePoint")]
        public async Task<IActionResult> CreatePoint([FromBody] PointInfoDTO point)
        {
            return Ok(await _point.CreatePoint(point));
        }
    }
}
