using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentralPayController : ControllerBase
    {
        private ICentralPayService _centralPayService;

        public CentralPayController(ICentralPayService centralPayService)
        {
            _centralPayService = centralPayService;
        }


        [HttpGet("GetAllCentralPayDetailByDate")]
        public IActionResult GetAllCentralPayDetailByDate(DateTime startDate, DateTime endDate)
        {
            var result = _centralPayService.GetAllCentralPayDetailByDate(startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(CentralPay centralPay)
        {
            var result = _centralPayService.Add(centralPay);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(CentralPay centralPay)
        {
            var result = _centralPayService.Delete(centralPay);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(CentralPay centralPay)
        {
            var result = _centralPayService.Update(centralPay);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
