using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {

        IDataResult<User> Login(UserForLoginDto userForLoginDto);
      
    }
}
