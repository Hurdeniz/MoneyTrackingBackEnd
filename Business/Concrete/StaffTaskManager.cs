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

namespace Business.Concrete
{
    public class StaffTaskManager : IStaffTaskService
    {
        private IStaffTaskDal _staffTaskDal;

        public StaffTaskManager(IStaffTaskDal staffTaskDal)
        {
            _staffTaskDal = staffTaskDal;
        }

        [SecuredOperation("Admin,StaffTask.GetAll")]
        [CacheAspect]
        public IDataResult<List<StaffTask>> GetAll()
        {
            return new SuccessDataResult<List<StaffTask>>(_staffTaskDal.GetAll(), Messages.StaffTaskListed);
        }

        [SecuredOperation("Admin,StaffTask.Add")]
        [CacheRemoveAspect("IStaffTaskService.Get")]
        [ValidationAspect(typeof(StaffTaskValidator))]
        public IResult Add(StaffTask staffTask)
        {
            IResult result = BusinessRules.Run(
             CheckIfStaffTaskNameExists(staffTask.StaffTaskName));

            if (result != null)
            {
                return result;
            }

            _staffTaskDal.Add(staffTask);
            return new SuccessResult(Messages.StaffTaskAdded);
        }


        [SecuredOperation("Admin,StaffTask.Update")]
        [CacheRemoveAspect("IStaffTaskService.Get")]
        [ValidationAspect(typeof(StaffTaskValidator))]
        public IResult Update(StaffTask staffTask)
        {
            IResult result = BusinessRules.Run(
            CheckIfStaffTaskNameExists(staffTask.StaffTaskName));

            if (result != null)
            {
                return result;
            }

            _staffTaskDal.Update(staffTask);
            return new SuccessResult(Messages.StaffTaskUpdated);
        }

        [SecuredOperation("Admin,StaffTask.Delete")]
        [CacheRemoveAspect("IStaffTaskService.Get")]
        public IResult Delete(StaffTask staffTask)
        {
            _staffTaskDal.Delete(staffTask);
            return new SuccessResult(Messages.StaffTaskDeleted);
        }
     

        private IResult CheckIfStaffTaskNameExists(string staffTaskName)
        {
            var result = _staffTaskDal.GetAll(t => t.StaffTaskName == staffTaskName).Any();
            if (result)
            {
                return new ErrorResult(Messages.StaffTaskAlreadyExists);
            }
            return new SuccessResult();
        }


    }
}
