using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class IncomingMoneyManager : IIncomingMoneyService
    {
        private IIncomingMoneyDal _incomingMoneyDal;
        private IFutureMoneyService _futureMoneyService;

        public IncomingMoneyManager(IIncomingMoneyDal incomingMoneyDal, IFutureMoneyService futureMoneyService)
        {
            _incomingMoneyDal = incomingMoneyDal;
            _futureMoneyService = futureMoneyService;
         
        }

        [SecuredOperation("Admin,IncomingMoney.GetAllIncomingMoneyDetail")]
        [CacheAspect]
        public IDataResult<List<IncomingMoneyDetailDto>> GetAllIncomingMoneyDetail() => new SuccessDataResult<List<IncomingMoneyDetailDto>>(_incomingMoneyDal.GetAllIncomingMoneyDetail(), Messages.IncomingMoneyListed);

        [CacheAspect]
        public IDataResult<List<IncomingMoneyGroupByCustomerDto>> GetAllIncomingMoneyByDateGroupByCustomer(DateTime date) => new SuccessDataResult<List<IncomingMoneyGroupByCustomerDto>>(_incomingMoneyDal.GetAllIncomingMoneyByDateGroupByCustomer(date));


        [SecuredOperation("Admin,IncomingMoney.Add")]
        [CacheRemoveAspect("IIncomingMoneyService.Get")]
        [TransactionScopeAspect]
        public IResult AddIncomingMoneyUpdateFutureMoney(IncomingMoneyDetailDto incomingMoneyDetailDto)
        {
            //IResult result = BusinessRules.Run(
            //   IncomingAmountCannotGreaterFutureAmount(incomingMoneyDetailDto.IncomingAmount, incomingMoneyDetailDto.FutureAmount));

            //if (result != null)
            //{
            //    return result;
            //}

            IncomingMoney incomingMoney = new IncomingMoney()
            {
                FutureMoneyId = incomingMoneyDetailDto.FutureMoneyId,
                IncomingAmount = incomingMoneyDetailDto.IncomingAmount,
                IncomingMoneyRegistrationDate = incomingMoneyDetailDto.IncomingMoneyRegistrationDate,
                Description = incomingMoneyDetailDto.InComingMoneyDescription,
                Status=incomingMoneyDetailDto.IncomingMoneyStatus,
            };

            _incomingMoneyDal.Add(incomingMoney);

            FutureMoney futureMoney = new FutureMoney()
            {
                FutureMoneyId = incomingMoneyDetailDto.FutureMoneyId,
                UserId = incomingMoneyDetailDto.UserId,
                TypeOfOperation = incomingMoneyDetailDto.TypeOfOperation,
                CustomerCode = incomingMoneyDetailDto.CustomerCode,
                CustomerNameSurname = incomingMoneyDetailDto.CustomerNameSurname,
                PromissoryNumber = incomingMoneyDetailDto.PromissoryNumber,
                TransactionAmount = incomingMoneyDetailDto.TransactionAmount,
                AmountPaid = incomingMoneyDetailDto.AmountPaid,
                FutureAmount = incomingMoneyDetailDto.FutureAmount,
                FutureMoneyRegistrationDate = incomingMoneyDetailDto.FutureMoneyRegistrationDate,
                Description = incomingMoneyDetailDto.FutureMoneyDescription,
                Status = incomingMoneyDetailDto.FutureMoneyStatus
            };

          
            _futureMoneyService.UpdateFutureMoney(futureMoney);
            return new SuccessResult(Messages.IncomingMoneyAdded);
        }

        [SecuredOperation("Admin,IncomingMoney.Delete")]
        [CacheRemoveAspect("IIncomingMoneyService.Get")]
        [TransactionScopeAspect]
        public IResult DeleteIncomingMoneyUpdateFutureMoney(IncomingMoneyDetailDto incomingMoneyDetailDto)
        {

            FutureMoney futureMoney = new FutureMoney()
            {
                FutureMoneyId = incomingMoneyDetailDto.FutureMoneyId,
                UserId = incomingMoneyDetailDto.UserId,
                TypeOfOperation = incomingMoneyDetailDto.TypeOfOperation,
                CustomerCode = incomingMoneyDetailDto.CustomerCode,
                CustomerNameSurname = incomingMoneyDetailDto.CustomerNameSurname,
                PromissoryNumber = incomingMoneyDetailDto.PromissoryNumber,
                TransactionAmount = incomingMoneyDetailDto.TransactionAmount,
                AmountPaid = incomingMoneyDetailDto.AmountPaid,
                FutureAmount = incomingMoneyDetailDto.FutureAmount,
                FutureMoneyRegistrationDate = incomingMoneyDetailDto.FutureMoneyRegistrationDate,
                Description = incomingMoneyDetailDto.FutureMoneyDescription,
                Status = incomingMoneyDetailDto.FutureMoneyStatus
            };

            _futureMoneyService.UpdateFutureMoney(futureMoney);

            IncomingMoney incomingMoney = new IncomingMoney()
            {
                IncomingMoneyId = incomingMoneyDetailDto.IncomingMoneyId,
                FutureMoneyId= incomingMoneyDetailDto.FutureMoneyId,
                IncomingAmount = incomingMoneyDetailDto.IncomingAmount,
                IncomingMoneyRegistrationDate = incomingMoneyDetailDto.IncomingMoneyRegistrationDate,
                Description = incomingMoneyDetailDto.InComingMoneyDescription,
                Status = incomingMoneyDetailDto.IncomingMoneyStatus,

            };
            
            _incomingMoneyDal.Delete(incomingMoney);       
            return new SuccessResult(Messages.IncomingMoneyDeleted);
        }

    
        private IResult IncomingAmountCannotGreaterFutureAmount(decimal incomingAmount,decimal futureAmount)
        {
            var result = futureAmount < incomingAmount;
            if (result)
            {
                return new ErrorResult(Messages.IncomingAmountCannotGreaterFutureAmount);
            }
            return new SuccessResult();
        }


    }
}
