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
    public class SatisfactionManager : ISatisfactionService
    {
        private ISatisfactionDal _satisfactionDal;

        public SatisfactionManager(ISatisfactionDal satisfactionDal)
        {
            _satisfactionDal = satisfactionDal;
        }

        [SecuredOperation("Admin,Service,Satisfaction.GetAllSatisfactionDetailByDate")]
        [CacheAspect]
        public IDataResult<List<Satisfaction>> GetAllSatisfactionDetailByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<Satisfaction>>(_satisfactionDal.GetAll(s => s.Date >= startDate && s.Date <= endDate).OrderByDescending(s => s.Date).ThenBy(s => s.CustomerNameSurname).ToList(), Messages.SatisfactionListed);


        [SecuredOperation("Admin,Service,Satisfaction.Add")]
        [CacheRemoveAspect("ISatisfactionService.Get")]
        [ValidationAspect(typeof(SatisfactionValidator))]
        public IResult Add(Satisfaction satisfaction)
        {
            _satisfactionDal.Add(satisfaction);
            return new SuccessResult(Messages.SatisfactionAdded);
        }

        [SecuredOperation("Admin,Service,Satisfaction.Update")]
        [CacheRemoveAspect("ISatisfactionService.Get")]
        [ValidationAspect(typeof(SatisfactionValidator))]
        public IResult Update(Satisfaction satisfaction)
        {
            _satisfactionDal.Update(satisfaction);
            return new SuccessResult(Messages.SatisfactionUpdated);
        }

        [SecuredOperation("Admin,Service,Satisfaction.Delete")]
        [CacheRemoveAspect("ISatisfactionService.Get")]
        public IResult Delete(Satisfaction satisfaction)
        {
            _satisfactionDal.Delete(satisfaction);
            return new SuccessResult(Messages.SatisfactionDeleted);
        }

 
    }
}
