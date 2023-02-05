using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserMenuManager : IUserMenuService
    {
        private IUserMenuDal _userMenuDal;

        public UserMenuManager(IUserMenuDal userMenuDal)
        {
            _userMenuDal = userMenuDal;
        }

        [CacheAspect]
       // [SecuredOperation("Admin,UserMenuClaim.GetAll")]
        public IDataResult<List<UserMenuClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserMenuClaim>>(_userMenuDal.GetAll(), Messages.UserMenuListed);
        }

        [CacheRemoveAspect("IUserMenuService.Get")]
       // [SecuredOperation("Admin,UserMenuClaim.Add")]
        public IResult Add(UserMenuClaim userMenuClaim)
        {
            _userMenuDal.Add(userMenuClaim);
            return new SuccessResult(Messages.UserMenuAdded);
        }

        [CacheRemoveAspect("IUserMenuService.Get")]
       // [SecuredOperation("Admin,UserMenuClaim.Update")]
        public IResult Update(UserMenuClaim userMenuClaim)
        {
            _userMenuDal.Update(userMenuClaim);
            return new SuccessResult(Messages.UserMenuUpdated);
        }

        [CacheRemoveAspect("IUserMenuService.Get")]
        //[SecuredOperation("Admin,UserMenuClaim.Delete")]
        public IResult Delete(UserMenuClaim userMenuClaim)
        {
            _userMenuDal.Delete(userMenuClaim);
            return new SuccessResult(Messages.BankDeleted);
        }
    }
}
