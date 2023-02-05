using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureMoneyCancellationController : ControllerBase
    {
        private IFutureMoneyCancellationService _futureMoneyCancellationService;

        public FutureMoneyCancellationController(IFutureMoneyCancellationService futureMoneyCancellationService)
        {
            _futureMoneyCancellationService = futureMoneyCancellationService;
        }

        [HttpGet("GetAllFutureMoneyCancellationDetail")]
        public IActionResult GetAllFutureMoneyCancellationDetail()
        {
            var result = _futureMoneyCancellationService.GetAllFutureMoneyCancellationDetail();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }

        [HttpGet("GetAllFutureMoneyCancellationByDateGroupByCustomer")]
        public IActionResult GetAllFutureMoneyCancellationByDateGroupByCustomer(DateTime date)
        {
            var result = _futureMoneyCancellationService.GetAllFutureMoneyCancellationByDateGroupByCustomer(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult AddFutureMoneyCancellationUpdateFutureMoney(FutureMoneyCancellationDetailDto futureMoneyCancellationDetailDto)
        {
            var result = _futureMoneyCancellationService.AddFutureMoneyCancellationUpdateFutureMoney(futureMoneyCancellationDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteFutureMoneyCancellationUpdateFutureMoney(FutureMoneyCancellationDetailDto futureMoneyCancellationDetailDto)
        {
            var result = _futureMoneyCancellationService.DeleteFutureMoneyCancellationUpdateFutureMoney(futureMoneyCancellationDetailDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
