using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStaffTaskService
    {
        IDataResult<List<StaffTask>> GetAll();
        IResult Add(StaffTask staffTask);
        IResult Update(StaffTask staffTask);
        IResult Delete(StaffTask staffTask);
    }
}
