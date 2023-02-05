using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetOperationClaims(int userId);
        List<MenuClaim> GetMenuClaims(int userId);
        List<UserOperationClaimDto> GetAllUserOperationClaims(int userId);
        List<UserMenuClaimDto> GetAllUserMenuClaims(int userId);
    }
}
