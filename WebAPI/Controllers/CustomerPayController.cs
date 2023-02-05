using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPayController : ControllerBase
    {
        private ICustomerPayService _customerPayService;

        public CustomerPayController(ICustomerPayService customerPayService)
        {
            _customerPayService = customerPayService;
        }

        [HttpGet("GetAllCustomerPayDetailByDate")]
        public IActionResult GetAllCustomerPayDetailByDate(DateTime startDate , DateTime endDate)
        {
            var result = _customerPayService.GetAllCustomerPayDetailByDate(startDate,endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(CustomerPay customerPay)
        {
            var result = _customerPayService.Add(customerPay);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(CustomerPay customerPay)
        {
            var result = _customerPayService.Delete(customerPay);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(CustomerPay customerPay)
        {
            var result = _customerPayService.Update(customerPay);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
