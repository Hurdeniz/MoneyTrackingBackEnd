using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureMoneyController : ControllerBase
    {
        private IFutureMoneyService _futureMoneyService;

        public FutureMoneyController(IFutureMoneyService futureMoneyService)
        {
            _futureMoneyService = futureMoneyService;
        }


        [HttpGet("GetAllFutureMoneyDetailByStatus")]
        public IActionResult GetAllFutureMoneyDetailByStatus(bool status)
        {
            var result = _futureMoneyService.GetAllFutureMoneyDetailByStatus(status);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllFutureMoneyDetailByUserIdAndStatus")]
        public IActionResult GetAllFutureMoneyDetailByUserIdAndStatus(int userId, bool status)
        {
            var result = _futureMoneyService.GetAllFutureMoneyDetailByUserIdAndStatus(userId, status);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllFutureMoneyByDateGroupByCustomer")]
        public IActionResult GetAllFutureMoneyByDateGroupByCustomer(DateTime date)
        {
            var result = _futureMoneyService.GetAllFutureMoneyByDateGroupByCustomer(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetSumByDateAndUser")]
        public IActionResult GetSumByDateAndUser(DateTime date, int userId)
        {
            var result = _futureMoneyService.GetSumByDateAndUser(date, userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(FutureMoney futureMoney)
        {
            var result = _futureMoneyService.Add(futureMoney);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(FutureMoney futureMoney)
        {
            var result = _futureMoneyService.Update(futureMoney);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(FutureMoney futureMoney)
        {
            var result = _futureMoneyService.Delete(futureMoney);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }



    }
}
