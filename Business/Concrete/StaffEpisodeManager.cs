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
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StaffEpisodeManager : IStaffEpisodeService
    {
        private IStaffEpisodeDal _staffEpisodeDal;

        public StaffEpisodeManager(IStaffEpisodeDal staffEpisodeDal)
        {
            _staffEpisodeDal = staffEpisodeDal;
        }

        [SecuredOperation("Admin,StaffEpisode.GetAll")]
        [CacheAspect]
        public IDataResult<List<StaffEpisode>> GetAll() => new SuccessDataResult<List<StaffEpisode>>(_staffEpisodeDal.GetAll(), Messages.StaffEpisodeListed);

        [SecuredOperation("Admin,StaffEpisode.Add")]
        [CacheRemoveAspect("IStaffEpisodeService.Get")]
        [ValidationAspect(typeof(StaffEpisodeValidator))]
        public IResult Add(StaffEpisode staffEpisode)
        {
            IResult result = BusinessRules.Run(
            CheckIfStaffEpisodeNameExists(staffEpisode.StaffEpisodeName));

            if (result != null)
            {
                return result;
            }

            _staffEpisodeDal.Add(staffEpisode);
            return new SuccessResult(Messages.StaffEpisodeAdded);
        }

        [SecuredOperation("Admin,StaffEpisode.Update")]
        [CacheRemoveAspect("IStaffEpisodeService.Get")]
        [ValidationAspect(typeof(StaffEpisodeValidator))]
        public IResult Update(StaffEpisode staffEpisode)
        {
            IResult result = BusinessRules.Run(
           CheckIfStaffEpisodeNameExists(staffEpisode.StaffEpisodeName));

            if (result != null)
            {
                return result;
            }

            _staffEpisodeDal.Update(staffEpisode);
            return new SuccessResult(Messages.StaffEpisodeUpdated);
        }

        [SecuredOperation("Admin,StaffEpisode.Delete")]
        [CacheRemoveAspect("IStaffEpisodeService.Get")]
        public IResult Delete(StaffEpisode staffEpisode)
        {
            _staffEpisodeDal.Delete(staffEpisode);
            return new SuccessResult(Messages.StaffEpisodeDeleted);
        }



        private IResult CheckIfStaffEpisodeNameExists(string staffEpisodeName)
        {
            var result = _staffEpisodeDal.GetAll(e => e.StaffEpisodeName == staffEpisodeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.StaffEpisodeNameAlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
