using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete
{
    public class EfMenuClaimDal : EfEntityRepositoryBase<MenuClaim, MoneyTrackingContext>, IMenuClaimDal
    {
    }
}
