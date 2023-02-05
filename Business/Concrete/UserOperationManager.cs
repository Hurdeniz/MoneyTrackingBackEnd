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
    public class UserOperationManager :IUserOperationService
    {
        private IUserOperationDal _userOperationDal;

        public UserOperationManager(IUserOperationDal userOperationDal)
        {
            _userOperationDal = userOperationDal;
        }

        [CacheAspect]
        //[SecuredOperation("Admin,UserMenuClaim.GetAll")]
        public IDataResult<List<UserOperationClaim>> GetAll(int userId) => new SuccessDataResult<List<UserOperationClaim>>(_userOperationDal.GetAll(u =>u.UserId==userId), Messages.UserOperationListed);

        [CacheRemoveAspect("IUserOperationService.Get")]
       // [SecuredOperation("Admin,UserOperationClaim.Add")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationAdded);
        }

        [CacheRemoveAspect("IUserOperationService.Get")]
      //  [SecuredOperation("Admin,UserOperationClaim.Update")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationUpdated);
        }

        [CacheRemoveAspect("IUserOperationService.Get")]
      //  [SecuredOperation("Admin,UserOperationClaim.Delete")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationDeleted);
        }
    }
}
