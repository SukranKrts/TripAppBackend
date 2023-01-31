using Microsoft.AspNetCore.Mvc;
using TripApplication.Data.DTO.CompanyDTO;
using TripApplication.Data.Entities;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController: ControllerBase
    {
        private readonly CompanyService _companyService;
        
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDTO company)
        {
            return Ok(await _companyService.CreateCompany(company));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyUpdateDTO company)
        {
            return Ok(await _companyService.UpdateCompany(company));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            return Ok(await _companyService.DeleteCompany(id));
        }

        [HttpGet]
        [Route("GetList/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return Ok(await _companyService.GetCompanyById(id));
        }
    }
}
