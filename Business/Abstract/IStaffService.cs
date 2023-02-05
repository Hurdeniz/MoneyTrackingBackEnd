using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IStaffService
    {
        IDataResult<List<StaffDetailDto>> GetAllStaffDetailByStatus(bool status);
        IResult Add(Staff staff);
        IResult Update(Staff staff);
        IResult Delete(Staff staff);
    }
}
