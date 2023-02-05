using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ExpenditureManager : IExpenditureService
    {
        private IExpenditureDal _expenditureDal;

        public ExpenditureManager(IExpenditureDal expenditureDal)
        {
            _expenditureDal = expenditureDal;
        }

        [SecuredOperation("Admin,Staff,Expenditure.GetAllExpenditureDetailByUserIdAndDate")]
        [CacheAspect]
        public IDataResult<List<ExpenditureDetailDto>> GetAllExpenditureDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate) => new SuccessDataResult<List<ExpenditureDetailDto>>(_expenditureDal.GetAllExpenditureDetailByUserIdAndDate(userId, startDate, endDate), Messages.ExpenditureListed);

        [CacheAspect]
        public IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId) => new SuccessDataResult<GetSumDto>(_expenditureDal.GetSumByDateAndUser(date, userId), Messages.ExpenditureTotal);

        [SecuredOperation("Admin,Staff,Expenditure.Add")]
        [CacheRemoveAspect("IExpenditureService.Get")]
        [ValidationAspect(typeof(ExpenditureValidator))]
        public IResult Add(Expenditure expenditure)
        {
            _expenditureDal.Add(expenditure);
            return new SuccessResult(Messages.ExpenditureAdded);
        }
    
        [SecuredOperation("Admin,Staff,Expenditure.Update")]
        [CacheRemoveAspect("IExpenditureService.Get")]
        [ValidationAspect(typeof(ExpenditureValidator))]
        public IResult Update(Expenditure expenditure)
        {
            _expenditureDal.Update(expenditure);
            return new SuccessResult(Messages.ExpenditureUpdated);
        }
    
        [SecuredOperation("Admin,Staff,Expenditure.Delete")]
        [CacheRemoveAspect("IExpenditureService.Get")]
        public IResult Delete(Expenditure expenditure)
        {
            _expenditureDal.Delete(expenditure);
            return new SuccessResult(Messages.ExpenditureDeleted);
        }
       
    }
}
