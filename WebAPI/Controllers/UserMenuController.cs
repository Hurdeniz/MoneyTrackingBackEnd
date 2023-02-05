using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMenuController : ControllerBase
    {
        private IUserMenuService _userMenuService;

        public UserMenuController(IUserMenuService userMenuService)
        {
            _userMenuService = userMenuService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userMenuService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("Update")]
        public IActionResult Update(UserMenuClaim userMenuClaim)
        {

            var result = _userMenuService.Update(userMenuClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
