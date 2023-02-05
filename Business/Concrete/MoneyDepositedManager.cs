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
using Entities.DTOs;

namespace Business.Concrete
{
    public class MoneyDepositedManager : IMoneyDepositedService
    {
        private IMoneyDepositedDal _moneyDepositedDal;

        public MoneyDepositedManager(IMoneyDepositedDal moneyDepositedDal)
        {
            _moneyDepositedDal = moneyDepositedDal;
        }

        [SecuredOperation("Admin,MoneyDeposited.GetAllMoneyDepositedDetailByDate")]
        [CacheAspect]
        public IDataResult<List<MoneyDepositedDetailDto>> GetAllMoneyDepositedDetailByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<MoneyDepositedDetailDto>>(_moneyDepositedDal.GetAllMoneyDepositedDetailByDate(startDate, endDate), Messages.MoneyDepositedListed);

        [SecuredOperation("Admin,MoneyDeposited.Add")]
        [CacheRemoveAspect("IMoneyDepositedService.Get")]
        [ValidationAspect(typeof(MoneyDepositedValidator))]
        public IResult Add(MoneyDeposited moneyDeposited)
        {
            _moneyDepositedDal.Add(moneyDeposited);
            return new SuccessResult(Messages.MoneyDepositedAdded);
        }

        [SecuredOperation("Admin,MoneyDeposited.Update")]
        [CacheRemoveAspect("IMoneyDepositedService.Get")]
        [ValidationAspect(typeof(MoneyDepositedValidator))]
        public IResult Update(MoneyDeposited moneyDeposited)
        {
            _moneyDepositedDal.Update(moneyDeposited);
            return new SuccessResult(Messages.MoneyDepositedUpdated);
        }

        [SecuredOperation("Admin,MoneyDeposited.Delete")]
        [CacheRemoveAspect("IMoneyDepositedService.Get")]
        public IResult Delete(MoneyDeposited moneyDeposited)
        {
            _moneyDepositedDal.Delete(moneyDeposited);
            return new SuccessResult(Messages.MoneyDepositedDeleted);
        }

    }
}
