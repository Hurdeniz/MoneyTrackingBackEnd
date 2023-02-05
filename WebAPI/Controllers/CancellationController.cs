using Business.Abstract;
using Business.Contans;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancellationController : ControllerBase
    {
        private ICancellationService _cancellationService;

        public CancellationController(ICancellationService cancellationService)
        {
            _cancellationService = cancellationService;
        }


        [HttpGet("GetAllCancellationDetailByDate")]
        public IActionResult GetAllCancellationDetailByDate(DateTime startDate, DateTime endDate)
        {
            var result = _cancellationService.GetAllCancellationDetailByDate(startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetSumByDateAndUser")]
        public IActionResult GetSumByDateAndUser(DateTime date, int userId)
        {
            var result = _cancellationService.GetSumByDateAndUser(date, userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("Add")]
        public IActionResult Add(Cancellation cancellation)
        {
            var result = _cancellationService.Add(cancellation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Cancellation cancellation)
        {
            var result = _cancellationService.Delete(cancellation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Cancellation cancellation)
        {
            var result = _cancellationService.Update(cancellation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

    }
}
