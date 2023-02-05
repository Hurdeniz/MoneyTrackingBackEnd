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
    public class CardPaymentManager : ICardPaymentService
    {
        private ICardPaymentDal _cardPaymentDal;

        public CardPaymentManager(ICardPaymentDal cardPaymentDal)
        {
            _cardPaymentDal = cardPaymentDal;
        }

        [SecuredOperation("Admin,Staff,CardPayment.GetAllCardPaymentDetailByUserIdAndDate")]
        [CacheAspect]
        public IDataResult<List<CardPaymentDetailDto>> GetAllCardPaymentDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate) => new SuccessDataResult<List<CardPaymentDetailDto>>(_cardPaymentDal.GetAllCardPaymentDetailByUserIdAndDate(userId, startDate, endDate), Messages.CardPaymentListed);

        [CacheAspect]
        public IDataResult<List<CardPaymentGroupByBankNameDto>> GetAllCardPaymentsByDateGroupByBankName(DateTime date) => new SuccessDataResult<List<CardPaymentGroupByBankNameDto>>(_cardPaymentDal.GetAllCardPaymentsByDateGroupByBankName(date), Messages.CardPaymentListed);

        [CacheAspect]
        public IDataResult<GetCountDto> GetCountByDate(DateTime date) => new SuccessDataResult<GetCountDto>(_cardPaymentDal.GetCountByDate(date), Messages.CardPaymentCount);

        [CacheAspect]
        public IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date , int userId) => new SuccessDataResult<GetSumDto>(_cardPaymentDal.GetSumByDateAndUser(date,userId), Messages.CardPaymentTotal);


        [SecuredOperation("Admin,Staff,CardPayment.Add")]
        [CacheRemoveAspect("ICardPaymentService.Get")]
        [ValidationAspect(typeof(CardPaymentValidator))]
        public IResult Add(CardPayment cardPayment)
        {

            _cardPaymentDal.Add(cardPayment);
            return new SuccessResult(Messages.CardPaymentAdded);
        }

        [CacheRemoveAspect("ICardPaymentService.Get")]
        [SecuredOperation("Admin,Staff,CardPayment.Update")]
        [ValidationAspect(typeof(CardPaymentValidator))]
        public IResult Update(CardPayment cardPayment)
        {
            _cardPaymentDal.Update(cardPayment);
            return new SuccessResult(Messages.CardPaymentUpdated);
        }

        [CacheRemoveAspect("ICardPaymentService.Get")]
        [SecuredOperation("Admin,Staff,CardPayment.Delete")]
        public IResult Delete(CardPayment cardPayment)
        {
            _cardPaymentDal.Delete(cardPayment);
            return new SuccessResult(Messages.CardPaymentDeleted);
        }


    }

}
