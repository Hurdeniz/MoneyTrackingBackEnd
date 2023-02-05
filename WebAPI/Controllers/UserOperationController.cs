using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationController : ControllerBase
    {
        private IUserOperationService _userOperationService;

        public UserOperationController(IUserOperationService userOperationService)
        {
            _userOperationService = userOperationService;
        }

        [HttpPost("Update")]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {

            var result = _userOperationService.Update(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
