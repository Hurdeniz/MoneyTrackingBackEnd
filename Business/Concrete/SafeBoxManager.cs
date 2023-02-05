using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class SafeBoxManager : ISafeBoxService
    {
        private ISafeBoxDal _safeBox;

        public SafeBoxManager(ISafeBoxDal safeBox)
        {
            _safeBox = safeBox;
        }

        [SecuredOperation("Admin,SafeBox.GetAllSafeBoxByDate")]
        [CacheAspect]
        public IDataResult<List<SafeBox>> GetAllSafeBoxByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<SafeBox>>(_safeBox.GetAll(s => s.Date >= startDate && s.Date <= endDate).OrderByDescending(s => s.Date).ToList(), Messages.SafeBoxListed);

        public IDataResult<GetTotalsDto> TotalsByDay(DateTime date) => new SuccessDataResult<GetTotalsDto>(_safeBox.TotalsByDay(date), Messages.TransactionTotalByDate);

        [CacheAspect]
        public IDataResult<GetCountDto> GetSafeBoxCountByDate(DateTime date) => new SuccessDataResult<GetCountDto>(_safeBox.GetSafeBoxCountByDate(date), Messages.SafeBoxCount);


        [SecuredOperation("Admin,SafeBox.Add")]
        [CacheRemoveAspect("ISafeBoxService.Get")]  
        public IResult Add(SafeBox safeBox)
        {
            IResult result = BusinessRules.Run(
          CheckIfDateExists(safeBox.Date));

            if (result != null)
            {
                return result;
            }

            _safeBox.Add(safeBox);
            return new SuccessResult(Messages.SafeBoxAdded);
        }

        [SecuredOperation("Admin,SafeBox.Update")]
        [CacheRemoveAspect("ISafeBoxService.Get")]
        public IResult Update(SafeBox safeBox)
        {

            _safeBox.Update(safeBox);
            return new SuccessResult(Messages.SafeBoxUpdated);
        }

        [SecuredOperation("Admin,SafeBox.Delete")]
        [CacheRemoveAspect("ISafeBoxService.Get")]
        public IResult Delete(SafeBox safeBox)
        {

            _safeBox.Delete(safeBox);
            return new SuccessResult(Messages.SafeBoxDeleted);
        }


        private IResult CheckIfDateExists(DateTime date)
        {
            var result = _safeBox.GetAll(s => s.Date == date).Any();
            if (result)
            {
                return new ErrorResult(Messages.DateAlreadyExists);
            }
            return new SuccessResult();
        }



    }
}
