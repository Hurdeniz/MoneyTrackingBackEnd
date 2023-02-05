using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(UserForAddDto userForAddDto, string password);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAllUserByStatus(bool status);
        IDataResult<User> GetByMail(string email);
        IResult Update(User user);
        IResult UpdatePassword(UserForPassworUpdateDto userForPassworUpdatedDto, string password);
        IDataResult<List<UserOperationClaimDto>> GetAllUserOperationClaims(int userId);
        IDataResult<List<UserMenuClaimDto>> GetAllUserMenuClaims(int userId);
    }
}
