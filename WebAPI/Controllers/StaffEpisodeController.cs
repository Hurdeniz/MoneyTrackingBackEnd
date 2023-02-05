using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffEpisodeController : ControllerBase
    {
        private IStaffEpisodeService _staffEpisodeService;

        public StaffEpisodeController(IStaffEpisodeService staffEpisodeService)
        {
            _staffEpisodeService = staffEpisodeService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _staffEpisodeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(StaffEpisode staffEpisode)
        {
            var result = _staffEpisodeService.Add(staffEpisode);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(StaffEpisode staffEpisode)
        {
            var result = _staffEpisodeService.Delete(staffEpisode);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(StaffEpisode staffEpisode)
        {
            var result = _staffEpisodeService.Update(staffEpisode);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
