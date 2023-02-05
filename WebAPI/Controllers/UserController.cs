using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
 

        public UserController(IUserService userService )
        {
            _userService = userService;
        }

        [HttpGet("GetAllUserByStatus")]
        public IActionResult GetAllUserByStatus(bool status)
        {
            var result = _userService.GetAllUserByStatus(status);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllUserOperationClaims")]
        public IActionResult GetAllUserOperationClaims(int userId)
        {
            var result = _userService.GetAllUserOperationClaims(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllUserMenuClaims")]
        public IActionResult GetAllUserMenuClaims(int userId)
        {
            var result = _userService.GetAllUserMenuClaims(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(UserForAddDto userForAddDto)
        {
       
            var result = _userService.Add(userForAddDto, userForAddDto.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(User user)
        {

            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword(UserForPassworUpdateDto userForPassworUpdateDto)
        {

            var result = _userService.UpdatePassword(userForPassworUpdateDto, userForPassworUpdateDto.Password);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {

            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
