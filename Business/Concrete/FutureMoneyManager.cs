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
    public class FutureMoneyManager : IFutureMoneyService
    {
        private IFutureMoneyDal _futureMoneyDal;


        public FutureMoneyManager(IFutureMoneyDal futureMoneyDal)
        {
            _futureMoneyDal = futureMoneyDal;

        }

        [SecuredOperation("Admin,FutureMoney.GetAllFutureMoneyDetailByStatus")]
        [CacheAspect]
        public IDataResult<List<FutureMoneyDetailDto>> GetAllFutureMoneyDetailByStatus(bool status)
        {
            if (status == true)
            {
                return new SuccessDataResult<List<FutureMoneyDetailDto>>(_futureMoneyDal.FutureMoneyDetailDto(f => f.Status == status), Messages.FutureMoneyActiveListed);
            }
            else
            {
                return new SuccessDataResult<List<FutureMoneyDetailDto>>(_futureMoneyDal.FutureMoneyDetailDto(f => f.Status == status), Messages.FutureMoneyPassiveListed);
            }

        }

        [SecuredOperation("Admin,Staff,FutureMoney.GetAllFutureMoneyDetailByUserIdAndStatus")]
        [CacheAspect]
        public IDataResult<List<FutureMoneyDetailDto>> GetAllFutureMoneyDetailByUserIdAndStatus(int userId, bool status)
        {
            if (status == true)
            {
                return new SuccessDataResult<List<FutureMoneyDetailDto>>(_futureMoneyDal.FutureMoneyDetailDto(f => f.UserId == userId && f.Status == status), Messages.FutureMoneyActiveListed);
            }
            else
            {
                return new SuccessDataResult<List<FutureMoneyDetailDto>>(_futureMoneyDal.FutureMoneyDetailDto(f => f.UserId == userId && f.Status == status), Messages.FutureMoneyPassiveListed);
            }

        }

        [CacheAspect()]
        public IDataResult<List<FutureMoneyGroupByCustomerDto>> GetAllFutureMoneyByDateGroupByCustomer(DateTime date) => new SuccessDataResult<List<FutureMoneyGroupByCustomerDto>>(_futureMoneyDal.GetAllFutureMoneyByDateGroupByCustomer(date));

        [CacheAspect]
        public IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId) => new SuccessDataResult<GetSumDto>(_futureMoneyDal.GetSumByDateAndUser(date, userId), Messages.FutureMoneyTotal);

        [SecuredOperation("Admin,Staff,FutureMoney.Add")]
        [CacheRemoveAspect("IFutureMoneyService.Get")]
        [ValidationAspect(typeof(FutureMoneyValidator))]
        public IResult Add(FutureMoney futureMoney)
        {
            IResult result = BusinessRules.Run(
                AmountPaidCannotGreaterTransactionAmount(futureMoney.AmountPaid , futureMoney.TransactionAmount ),
                CheckIfPromissoryNumberExists(futureMoney.PromissoryNumber),
                CheckIfTransactionAmountAndAmountPaidSame(futureMoney.TransactionAmount, futureMoney.AmountPaid));

            if (result != null)
            {
                return result;
            }

            _futureMoneyDal.Add(futureMoney);
            return new SuccessResult(Messages.FutureMoneyAdded);
        }

        [SecuredOperation("Admin,Staff,FutureMoney.Update")]
        [CacheRemoveAspect("IFutureMoneyService.Get")]
        [ValidationAspect(typeof(FutureMoneyValidator))]
        public IResult Update(FutureMoney futureMoney)
        {

            IResult result = BusinessRules.Run(
                CheckIfTransactionAmountAndAmountPaidSame(futureMoney.TransactionAmount, futureMoney.AmountPaid),
                AmountPaidCannotGreaterTransactionAmount(futureMoney.AmountPaid, futureMoney.TransactionAmount),
                CheckIfIncomingMoneyExists(futureMoney.FutureMoneyId, futureMoney.FutureAmount));

            if (result != null)
            {
                return result;
            }

            _futureMoneyDal.Update(futureMoney);
            return new SuccessResult(Messages.FutureMoneyUpdated);
        }

        [CacheRemoveAspect("IFutureMoneyService.Get")]
        public IResult UpdateFutureMoney(FutureMoney futureMoney)
        {

            _futureMoneyDal.Update(futureMoney);
            return new SuccessResult(Messages.FutureMoneyUpdated);
        }



        [SecuredOperation("Admin,Staff,FutureMoney.Delete")]
        [CacheRemoveAspect("IFutureMoneyService.Get")]
        public IResult Delete(FutureMoney futureMoney)
        {
            _futureMoneyDal.Delete(futureMoney);
            return new SuccessResult(Messages.FutureMoneyDeleted);
        }


        private IResult CheckIfPromissoryNumberExists(string promissoryNumber)
        {
            var result = _futureMoneyDal.GetAll(f => f.PromissoryNumber == promissoryNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.PromissoryNumberAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult AmountPaidCannotGreaterTransactionAmount(decimal amountPaid,decimal transactionAmount)
        {
            var result = transactionAmount < amountPaid;
            if (result)
            {
                return new ErrorResult(Messages.AmountPaidCannotGreaterTransactionAmount);
            }
            return new SuccessResult();
        }

        private IResult CheckIfTransactionAmountAndAmountPaidSame(decimal transactionAmount, decimal amountPaid)
        {
            var result = transactionAmount == amountPaid;
            if (result)
            {
                return new ErrorResult(Messages.TransactionAmountAndAmountPaidSame);
            }
            return new SuccessResult();
        }

        private IResult CheckIfIncomingMoneyExists(int futureMoneyId, decimal futureMoney)
        {
            var result = _futureMoneyDal.TotalIncomingMoney(futureMoneyId);
            if (result.Sum > futureMoney)
            {
                return new ErrorResult(Messages.CheckIfIncomingMoneyExists);
            }
            return new SuccessResult();
        }


    }
}
