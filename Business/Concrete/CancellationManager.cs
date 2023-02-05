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
    public class CancellationManager : ICancellationService
    {
        private ICancellationDal _cancellationDal;

        public CancellationManager(ICancellationDal cancellationDal)
        {
            _cancellationDal = cancellationDal;
        }

        [SecuredOperation("Admin,Cancellation.GetAllCancellationDetailByDate")]
        [CacheAspect]
        public IDataResult<List<CancellationDetailDto>> GetAllCancellationDetailByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<CancellationDetailDto>>(_cancellationDal.GetAllCancellationDetailByDate(startDate, endDate), Messages.CancellationListed);

        [CacheAspect]
        public IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId) => new SuccessDataResult<GetSumDto>(_cancellationDal.GetSumByDateAndUser(date, userId), Messages.CancellationTotal);


        [SecuredOperation("Admin,Cancellation.Add")]
        [CacheRemoveAspect("ICancellationService.Get")]
        [ValidationAspect(typeof(CancellationValidator))]
        public IResult Add(Cancellation cancellation)
        {
            IResult result = BusinessRules.Run(
              CheckIfPromissoryNumberExists(cancellation.PromissoryNumber));

            if (result != null)
            {
                return result;
            }

            _cancellationDal.Add(cancellation);
            return new SuccessResult(Messages.CancellationAdded);
        }

        [SecuredOperation("Admin,Cancellation.Update")]
        [CacheRemoveAspect("ICancellationService.Get")]
        [ValidationAspect(typeof(CancellationValidator))]
        public IResult Update(Cancellation cancellation)
        {
            _cancellationDal.Update(cancellation);
            return new SuccessResult(Messages.CancellationUpdated);
        }

        [SecuredOperation("Admin,Cancellation.Delete")]
        [CacheRemoveAspect("ICancellationService.Get")]
        public IResult Delete(Cancellation cancellation)
        {
            _cancellationDal.Delete(cancellation);
            return new SuccessResult(Messages.CancellationDeleted);
        }

        private IResult CheckIfPromissoryNumberExists(string promissoryNumber)
        {
            var result = _cancellationDal.GetAll(c => c.PromissoryNumber == promissoryNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.PromissoryNumberAlreadyExists);
            }
            return new SuccessResult();
        }


    }
}
