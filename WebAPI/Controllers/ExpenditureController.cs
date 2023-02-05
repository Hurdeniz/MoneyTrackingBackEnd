using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private IExpenditureService _expenditureService;

        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        [HttpGet("GetAllExpenditureDetailByUserIdAndDate")]
        public IActionResult GetAllExpenditureDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate)
        {
            var result = _expenditureService.GetAllExpenditureDetailByUserIdAndDate(userId, startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetSumByDateAndUser")]
        public IActionResult GetSumByDateAndUser(DateTime date, int userId)
        {
            var result = _expenditureService.GetSumByDateAndUser(date, userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("Add")]
        public IActionResult Add(Expenditure expenditure)
        {
            var result = _expenditureService.Add(expenditure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Expenditure expenditure)
        {
            var result = _expenditureService.Delete(expenditure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Expenditure expenditure)
        {
            var result = _expenditureService.Update(expenditure);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
