using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyOutputController : ControllerBase
    {
       private IMoneyOutputService _moneyOutputService;

        public MoneyOutputController(IMoneyOutputService moneyOutputService)
        {
            _moneyOutputService = moneyOutputService;
        }

        [HttpGet("GetAllMoneyOutputDetailByUserIdAndDate")]
        public IActionResult GetAllMoneyOutputDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate)
        {
            var result = _moneyOutputService.GetAllMoneyOutputDetailByUserIdAndDate(userId, startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllMoneyOutputDetailByDate")]
        public IActionResult GetAllMoneyOutputDetailByDate(DateTime startDate, DateTime endDate)
        {
            var result = _moneyOutputService.GetAllMoneyOutputDetailByDate(startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllMoneyOutputDetailByDay")]
        public IActionResult GetAllMoneyOutputDetailByDay(DateTime day)
        {
            var result = _moneyOutputService.GetAllMoneyOutputDetailByDay(day);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(MoneyOutput moneyOutput)
        {
            var result = _moneyOutputService.Add(moneyOutput);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(MoneyOutput moneyOutput)
        {
            var result = _moneyOutputService.Update(moneyOutput);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(MoneyOutput moneyOutput)
        {
            var result = _moneyOutputService.Delete(moneyOutput);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    
    }
}
