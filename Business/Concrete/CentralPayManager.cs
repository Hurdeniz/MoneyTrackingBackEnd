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
    public class CentralPayManager : ICentralPayService
    {
        private ICentralPayDal _centralPayDal;

        public CentralPayManager(ICentralPayDal centralPayDal)
        {
            _centralPayDal = centralPayDal;
        }

        [SecuredOperation("Admin,CentralPay.GetAllCentralPayDetailByDate")]
        [CacheAspect]
        public IDataResult<List<CentralPay>> GetAllCentralPayDetailByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<CentralPay>>(_centralPayDal.GetAll(c => c.Date >= startDate && c.Date <= endDate).OrderByDescending(c => c.Date).ThenBy(c => c.Amount).ToList(), Messages.CentralPayListed);
        
        [SecuredOperation("Admin,CentralPay.Add")]
        [CacheRemoveAspect("ICentralPayService.Get")]
        [ValidationAspect(typeof(CentralPayValidator))]
        public IResult Add(CentralPay centralPay)
        {
            _centralPayDal.Add(centralPay);
            return new SuccessResult(Messages.CentralPayAdded);
        }

        [SecuredOperation("Admin,CentralPay.Update")]
        [CacheRemoveAspect("ICentralPayService.Get")]
        [ValidationAspect(typeof(CentralPayValidator))]
        public IResult Update(CentralPay centralPay)
        {
            _centralPayDal.Update(centralPay);
            return new SuccessResult(Messages.CentralPayUpdated);
        }

        [SecuredOperation("Admin,CentralPay.Delete")]
        [CacheRemoveAspect("ICentralPayService.Get")]
        public IResult Delete(CentralPay centralPay)
        {
            _centralPayDal.Delete(centralPay);
            return new SuccessResult(Messages.CentralPayDeleted);
        }

    }
}
