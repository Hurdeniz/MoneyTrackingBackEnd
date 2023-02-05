using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingMoneyController : ControllerBase
    {
        private IIncomingMoneyService _incomingMoneyService;

        public IncomingMoneyController(IIncomingMoneyService incomingMoneyService)
        {
            _incomingMoneyService = incomingMoneyService;
        }


        [HttpGet("GetAllIncomingMoneyDetail")]
        public IActionResult GetAllIncomingMoneyDetail()
        {
            var result = _incomingMoneyService.GetAllIncomingMoneyDetail();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }

        [HttpGet("GetAllIncomingMoneyByDateGroupByCustomer")]
        public IActionResult GetAllIncomingMoneyByDateGroupByCustomer(DateTime date)
        {
            var result = _incomingMoneyService.GetAllIncomingMoneyByDateGroupByCustomer(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult AddIncomingMoneyUpdateFutureMoney(IncomingMoneyDetailDto incomingMoneyDetailDto)
        {
            var result = _incomingMoneyService.AddIncomingMoneyUpdateFutureMoney(incomingMoneyDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteIncomingMoneyUpdateFutureMoney(IncomingMoneyDetailDto incomingMoneyDetailDto)
        {
            var result = _incomingMoneyService.DeleteIncomingMoneyUpdateFutureMoney(incomingMoneyDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
