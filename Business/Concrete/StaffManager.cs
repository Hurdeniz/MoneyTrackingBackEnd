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
    public class StaffManager : IStaffService
    {
        private IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        [SecuredOperation("Admin,Staff.GetAllStaffDetailByStatus")]
        [CacheAspect]
        public IDataResult<List<StaffDetailDto>> GetAllStaffDetailByStatus(bool status)
        {
            if (status == true)
            {
                return new SuccessDataResult<List<StaffDetailDto>>(_staffDal.GetAllStaffDetailByStatus(status), Messages.StafsActiveListed);
            }
            else
            {
                return new SuccessDataResult<List<StaffDetailDto>>(_staffDal.GetAllStaffDetailByStatus(status), Messages.StaffPassiveListed);
            }

        }


        [SecuredOperation("Admin,Staff.Add")]
        [CacheRemoveAspect("IStaffService.Get")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Add(Staff staff)
        {

            IResult result = BusinessRules.Run(
         CheckIfStaffIdentityNumberExists(staff.IdentityNumber));

            if (result != null)
            {
                return result;
            }

            _staffDal.Add(staff);
            return new SuccessResult(Messages.StaffAdded);
        }

        [SecuredOperation("Admin,Staff.Update")]
        [CacheRemoveAspect("IStaffService.Get")]
        [ValidationAspect(typeof(StaffValidator))]
        public IResult Update(Staff staff)
        {
            _staffDal.Update(staff);
            return new SuccessResult(Messages.StaffUpdated);
        }

 

        [SecuredOperation("Admin,Staff.Delete")]
        [CacheRemoveAspect("IStaffService.Get")]
        public IResult Delete(Staff staff)
        {
            _staffDal.Delete(staff);
            return new SuccessResult(Messages.StaffDeleted);
        }

        private IResult CheckIfStaffIdentityNumberExists(string identityNumber)
        {
            var result = _staffDal.GetAll(s => s.IdentityNumber == identityNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.StaffIdentityNumberExists);
            }
            return new SuccessResult();
        }
    }
}
