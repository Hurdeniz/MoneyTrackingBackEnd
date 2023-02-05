using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IStaffDal : IEntityRepository<Staff>
    {
        List<StaffDetailDto> GetAllStaffDetailByStatus(bool status);
      
    }
}
