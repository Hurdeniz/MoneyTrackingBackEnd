using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserMenuService
    {
        IResult Add(UserMenuClaim userMenuClaim);
        IResult Delete(UserMenuClaim userMenuClaim);
        IDataResult<List<UserMenuClaim>> GetAll();
        IResult Update(UserMenuClaim userMenuClaim);
    }
}
