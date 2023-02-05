using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class MoneyOutputManager : IMoneyOutputService
    {
        IMoneyOutputDal _moneyOutputDal;

        public MoneyOutputManager(IMoneyOutputDal moneyOutputDal)
        {
            _moneyOutputDal = moneyOutputDal;
        }

        [SecuredOperation("Admin,Staff,MoneyOutput.GetAllMoneyOutputDetailByUserIdAndDate")]
        [CacheAspect]
        public IDataResult<List<MoneyOutput>> GetAllMoneyOutputDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate) => new SuccessDataResult<List<MoneyOutput>>(_moneyOutputDal.GetAll(m => m.UserId == userId && m.Date >= startDate && m.Date <= endDate).OrderByDescending(m => m.Date).ToList(), Messages.MoneyOutputListed);

        [SecuredOperation("Admin,MoneyOutput.GetAllMoneyOutputDetailByDate")]
        [CacheAspect]
        public IDataResult<List<MoneyOutputDetailDto>> GetAllMoneyOutputDetailByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<MoneyOutputDetailDto>>(_moneyOutputDal.MoneyOutputDetailDto(m => m.Date >= startDate && m.Date <= endDate), Messages.MoneyOutputListed);

    
        [CacheAspect]
        public IDataResult<List<MoneyOutputDetailDto>> GetAllMoneyOutputDetailByDay(DateTime day) => new SuccessDataResult<List<MoneyOutputDetailDto>>(_moneyOutputDal.MoneyOutputDetailDto(m => m.Date == day), Messages.MoneyOutputListed);


        [SecuredOperation("Admin,Staff,MoneyOutput.Add")]
        [CacheRemoveAspect("IMoneyOutputService.Get")]
        [ValidationAspect(typeof(MoneyOutputValidator))]
        public IResult Add(MoneyOutput moneyOutput)
        {
            IResult result = BusinessRules.Run(
            CheckIfDateExists(moneyOutput.Date, moneyOutput.UserId));

            if (result != null)
            {
                return result;
            }

            _moneyOutputDal.Add(moneyOutput);
            return new SuccessResult(Messages.MoneyOutputAdded);
        }

        [SecuredOperation("Admin,Staff,MoneyOutput.Update")]
        [CacheRemoveAspect("IMoneyOutputService.Get")]
        [ValidationAspect(typeof(MoneyOutputValidator))]
        public IResult Update(MoneyOutput moneyOutput)
        {

            _moneyOutputDal.Update(moneyOutput);
            return new SuccessResult(Messages.MoneyOutputUpdated);
        }

        [SecuredOperation("Admin,Staff,MoneyOutput.Delete")]
        [CacheRemoveAspect("IMoneyOutputService.Get")]
        public IResult Delete(MoneyOutput moneyOutput)
        {
            _moneyOutputDal.Delete(moneyOutput);
            return new SuccessResult(Messages.MoneyOutputDeleted);
        }

        private IResult CheckIfDateExists(DateTime date, int userId)
        {
            var result = _moneyOutputDal.GetAll(m => m.Date == date && m.UserId == userId).Any();
            if (result)
            {
                return new ErrorResult(Messages.MoneyOutputAlreadyExists);
            }
            return new SuccessResult();
        }




    }
}
