using Business.Abstract;
using Business.Contans;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class MenuClaimManager :IMenuClaimService
    {
        private IMenuClaimDal _menuClaimDal;

        public MenuClaimManager(IMenuClaimDal menuClaimDal)
        {
            _menuClaimDal = menuClaimDal;
        }

        public IDataResult<List<MenuClaim>> GetAll() => new SuccessDataResult<List<MenuClaim>>(_menuClaimDal.GetAll(), Messages.MenuListed);
    }
}
