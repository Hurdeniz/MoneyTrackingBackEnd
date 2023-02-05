using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FutureMoneyCancellationManager :IFutureMoneyCancellationService
    {
        private IFutureMoneyCancellationDal _futureMoneyCancellationDal;
        private IFutureMoneyService _futureMoneyService;

        public FutureMoneyCancellationManager(IFutureMoneyCancellationDal futureMoneyCancellationDal, IFutureMoneyService futureMoneyService)
        {
            _futureMoneyCancellationDal = futureMoneyCancellationDal;
            _futureMoneyService = futureMoneyService;
        }

        [SecuredOperation("Admin,FutureMoneyCancellation.GetAllFutureMoneyCancellationDetail")]
        [CacheAspect]
        public IDataResult<List<FutureMoneyCancellationDetailDto>> GetAllFutureMoneyCancellationDetail() => new SuccessDataResult<List<FutureMoneyCancellationDetailDto>>(_futureMoneyCancellationDal.GetAllFutureMoneyCancellationDetail(), Messages.FutureMoneyCancellationListed);


        [SecuredOperation("Admin,FutureMoneyCancellation.GetAllFutureMoneyCancellationByDateGroupByCustomer")]
        [CacheAspect]
        public IDataResult<List<FutureMoneyCancellationGroupByCustomerDto>> GetAllFutureMoneyCancellationByDateGroupByCustomer(DateTime date) => new SuccessDataResult<List<FutureMoneyCancellationGroupByCustomerDto>>(_futureMoneyCancellationDal.GetAllFutureMoneyCancellationByDateGroupByCustomer(date));


        [SecuredOperation("Admin,FutureMoneyCancellation.Add")]
        [CacheRemoveAspect("IFutureMoneyCancellationService.Get")]
        [TransactionScopeAspect]
        public IResult AddFutureMoneyCancellationUpdateFutureMoney(FutureMoneyCancellationDetailDto futureMoneyCancellationDetailDto)
        {
            
            FutureMoneyCancellation futureMoneyCancellation = new FutureMoneyCancellation()
            {
                FutureMoneyId = futureMoneyCancellationDetailDto.FutureMoneyId,
                FutureMoneyCancellationAmount = futureMoneyCancellationDetailDto.FutureMoneyCancellationAmount,
                FutureMoneyCancellationRegistrationDate = futureMoneyCancellationDetailDto.FutureMoneyCancellationRegistrationDate,
                Description=futureMoneyCancellationDetailDto.FutureMoneyCancellationDescription
            
            };

            _futureMoneyCancellationDal.Add(futureMoneyCancellation);

            FutureMoney futureMoney = new FutureMoney()
            {
                FutureMoneyId = futureMoneyCancellationDetailDto.FutureMoneyId,
                UserId = futureMoneyCancellationDetailDto.UserId,
                TypeOfOperation = futureMoneyCancellationDetailDto.TypeOfOperation,
                CustomerCode = futureMoneyCancellationDetailDto.CustomerCode,
                CustomerNameSurname = futureMoneyCancellationDetailDto.CustomerNameSurname,
                PromissoryNumber = futureMoneyCancellationDetailDto.PromissoryNumber,
                TransactionAmount = futureMoneyCancellationDetailDto.TransactionAmount,
                AmountPaid = futureMoneyCancellationDetailDto.FutureAmount,
                FutureMoneyRegistrationDate = futureMoneyCancellationDetailDto.FutureMoneyRegistrationDate,
                Description = futureMoneyCancellationDetailDto.FutureMoneyDescription,
                Status = futureMoneyCancellationDetailDto.FutureMoneyStatus
            };

         
            _futureMoneyService.UpdateFutureMoney(futureMoney);
            return new SuccessResult(Messages.FutureMoneyCancellationAdded);
        }

        [SecuredOperation("Admin,FutureMoneyCancellation.Delete")]
        [CacheRemoveAspect("IFutureMoneyCancellationService.Get")]
        [TransactionScopeAspect]
        public IResult DeleteFutureMoneyCancellationUpdateFutureMoney(FutureMoneyCancellationDetailDto futureMoneyCancellationDetailDto)
        {
         
            FutureMoney futureMoney = new FutureMoney()
            {
                FutureMoneyId = futureMoneyCancellationDetailDto.FutureMoneyId,
                UserId = futureMoneyCancellationDetailDto.UserId,
                TypeOfOperation = futureMoneyCancellationDetailDto.TypeOfOperation,
                CustomerCode = futureMoneyCancellationDetailDto.CustomerCode,
                CustomerNameSurname = futureMoneyCancellationDetailDto.CustomerNameSurname,
                PromissoryNumber = futureMoneyCancellationDetailDto.PromissoryNumber,
                TransactionAmount = futureMoneyCancellationDetailDto.TransactionAmount,
                AmountPaid = futureMoneyCancellationDetailDto.AmountPaid,
                FutureAmount = futureMoneyCancellationDetailDto.FutureAmount,
                FutureMoneyRegistrationDate = futureMoneyCancellationDetailDto.FutureMoneyRegistrationDate,
                Description = futureMoneyCancellationDetailDto.FutureMoneyDescription,
                Status = futureMoneyCancellationDetailDto.FutureMoneyStatus
            };

            _futureMoneyService.UpdateFutureMoney(futureMoney);

            FutureMoneyCancellation futureMoneyCancellation = new FutureMoneyCancellation()
            {
                FutureMoneyCancellationId = futureMoneyCancellationDetailDto.FutureMoneyCancellationId,
                FutureMoneyId = futureMoneyCancellationDetailDto.FutureMoneyId,
                FutureMoneyCancellationAmount = futureMoneyCancellationDetailDto.FutureMoneyCancellationAmount,
                FutureMoneyCancellationRegistrationDate = futureMoneyCancellationDetailDto.FutureMoneyCancellationRegistrationDate,
                Description = futureMoneyCancellationDetailDto.FutureMoneyCancellationDescription
            };

            
            _futureMoneyCancellationDal.Delete(futureMoneyCancellation);
           
            
            return new SuccessResult(Messages.FutureMoneyCancellationDeleted);
        }
    }
}
