using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyDepositedController : ControllerBase
    {
        private IMoneyDepositedService _moneyDepositedService;

        public MoneyDepositedController(IMoneyDepositedService moneyDepositedService)
        {
            _moneyDepositedService = moneyDepositedService;
        }


        [HttpGet("GetAllMoneyDepositedDetailByDate")]
        public IActionResult GetAllMoneyDepositedDetailByDate(DateTime startDate , DateTime endDate)
        {
            var result = _moneyDepositedService.GetAllMoneyDepositedDetailByDate(startDate,endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(MoneyDeposited moneyDeposited)
        {
            var result = _moneyDepositedService.Add(moneyDeposited);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(MoneyDeposited moneyDeposited)
        {
            var result = _moneyDepositedService.Delete(moneyDeposited);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(MoneyDeposited moneyDeposited)
        {
            var result = _moneyDepositedService.Update(moneyDeposited);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
