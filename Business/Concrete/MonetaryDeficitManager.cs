using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MonetaryDeficitManager : IMonetaryDeficitService
    {

        private IMonetaryDeficitDal _monetaryDeficitDal;

        public MonetaryDeficitManager(IMonetaryDeficitDal monetaryDeficitDal)
        {
            _monetaryDeficitDal = monetaryDeficitDal;
        }

        [SecuredOperation("Admin,MonetaryDeficit.GetAll")]
        [CacheAspect]
        public IDataResult<List<MonetaryDeficit>> GetAll()
        {
            return new SuccessDataResult<List<MonetaryDeficit>>(_monetaryDeficitDal.GetAll(), Messages.MonetaryDeficitListed);
        }

        [SecuredOperation("Admin,MonetaryDeficit.Add")]
        [CacheRemoveAspect("IMonetaryDeficitService.Get")]
        [ValidationAspect(typeof(MonetaryDeficitValidator))]
        public IResult Add(MonetaryDeficit monetaryDeficit)
        {
            _monetaryDeficitDal.Add(monetaryDeficit);
            return new SuccessResult(Messages.MonetaryDeficitAdded);
        }


        [SecuredOperation("Admin,MonetaryDeficit.Update")]
        [CacheRemoveAspect("IMonetaryDeficitService.Get")]
        [ValidationAspect(typeof(MonetaryDeficitValidator))]
        public IResult Update(MonetaryDeficit monetaryDeficit)
        {
            _monetaryDeficitDal.Update(monetaryDeficit);
            return new SuccessResult(Messages.MonetaryDeficitUpdated);
        }

        [SecuredOperation("Admin,MonetaryDeficit.Delete")]
        [CacheRemoveAspect("IMonetaryDeficitService.Get")]
        public IResult Delete(MonetaryDeficit monetaryDeficit)
        {
            _monetaryDeficitDal.Delete(monetaryDeficit);
            return new SuccessResult(Messages.MonetaryDeficitDeleted);
        }


    }
}
