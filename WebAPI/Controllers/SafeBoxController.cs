using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafeBoxController : ControllerBase
    {
        private ISafeBoxService _safeBoxService;

        public SafeBoxController(ISafeBoxService safeBoxService)
        {
            _safeBoxService = safeBoxService;
        }

        [HttpGet("GetAllSafeBoxByDate")]
        public IActionResult GetAllSafeBoxByDate(DateTime startDate,DateTime endDate)
        {
            var result = _safeBoxService.GetAllSafeBoxByDate(startDate,endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("TotalsByDay")]
        public IActionResult TotalsByDay(DateTime date)
        {
            var result = _safeBoxService.TotalsByDay(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetSafeBoxCountByDate")]
        public IActionResult GetSafeBoxCountByDate(DateTime date)
        {
            var result = _safeBoxService.GetSafeBoxCountByDate(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }




        [HttpPost("Add")]
        public IActionResult Add(SafeBox safeBox)
        {
            var result = _safeBoxService.Add(safeBox);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(SafeBox safeBox)
        {
            var result = _safeBoxService.Delete(safeBox);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(SafeBox safeBox)
        {
            var result = _safeBoxService.Update(safeBox);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
