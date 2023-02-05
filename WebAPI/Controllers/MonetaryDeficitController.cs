using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonetaryDeficitController : ControllerBase
    {
        private IMonetaryDeficitService _monetaryDeficitService;

        public MonetaryDeficitController(IMonetaryDeficitService monetaryDeficitService)
        {
            _monetaryDeficitService = monetaryDeficitService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _monetaryDeficitService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(MonetaryDeficit monetaryDeficit)
        {
            var result = _monetaryDeficitService.Add(monetaryDeficit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(MonetaryDeficit monetaryDeficit)
        {
            var result = _monetaryDeficitService.Delete(monetaryDeficit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(MonetaryDeficit monetaryDeficit)
        {
            var result = _monetaryDeficitService.Update(monetaryDeficit);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
