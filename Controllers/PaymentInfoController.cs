using Microsoft.AspNetCore.Mvc;
using TripApplication.Common;
using TripApplication.Data.DTO.PaymentDTO;
using TripApplication.Services;

namespace TripApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentInfoController: ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentInfoController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        
        [HttpPost]
        [Route("CreatePaymentInfo")]
        public async Task<IActionResult> CreatePaymentInfo([FromBody] PaymentInformationDTO payment)
        {
            return Ok(await _paymentService.CreatePaymentInfo(payment));
        }

        [HttpPut]
        [Route("UpdatePaymentInfo")]
        public async Task<IActionResult> UpdatePaymentInfo([FromBody] PaymentInformationDTO payment)
        {
            return Ok(await _paymentService.UpdatePaymentInfo(payment));
        }

        [HttpDelete]
        [Route("DeletePaymentInfo")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            return Ok(await _paymentService.DeletePaymentInfo(id));
        }

        [HttpGet]
        [Route("GetPayment")]
        public async Task<Result<List<PaymentInfoDTO>>> GetPayment()
        {
            return await _paymentService.GetPaymentInfo();
        }

        [HttpGet]
        [Route("GetPayment/id")]
        public async Task<Result<List<PaymentInfoDTO>>> GetPaymentById(int id)
        {
            return await _paymentService.GetPaymentInfoById(id);
        }

    }
}
