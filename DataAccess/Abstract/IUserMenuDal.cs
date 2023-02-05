using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserMenuDal : IEntityRepository<UserMenuClaim>
    {
    }
}
