using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisfactionController : ControllerBase
    {
        private ISatisfactionService _satisfactionServiceservice;

        public SatisfactionController(ISatisfactionService satisfactionServiceservice)
        {
            _satisfactionServiceservice = satisfactionServiceservice;
        }

        [HttpGet("GetAllSatisfactionDetailByDate")]
        public IActionResult GetAllSatisfactionDetailByDate(DateTime startDate , DateTime endDate)
        {
            var result = _satisfactionServiceservice.GetAllSatisfactionDetailByDate(startDate,endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Satisfaction satisfaction)
        {
            var result = _satisfactionServiceservice.Add(satisfaction);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Satisfaction satisfaction)
        {
            var result = _satisfactionServiceservice.Delete(satisfaction);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Satisfaction satisfaction)
        {
            var result = _satisfactionServiceservice.Update(satisfaction);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
