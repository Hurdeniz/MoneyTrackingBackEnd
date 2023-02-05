using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffTaskController : ControllerBase
    {
        IStaffTaskService _staffTaskService;

        public StaffTaskController(IStaffTaskService staffTaskService)
        {
            _staffTaskService = staffTaskService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _staffTaskService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(StaffTask staffTask)
        {
            var result = _staffTaskService.Add(staffTask);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(StaffTask staffTask)
        {
            var result = _staffTaskService.Delete(staffTask);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(StaffTask staffTask)
        {
            var result = _staffTaskService.Update(staffTask);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
