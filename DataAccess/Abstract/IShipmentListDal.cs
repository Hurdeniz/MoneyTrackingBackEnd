using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IShipmentListDal : IEntityRepository<ShipmentList>
    {
        List<ShipmentListDetailDto> GetAllShipmentListDetailByStatusAndDate(bool status, DateTime startDate, DateTime endDate);
        GetCountDto GetCountByDate(DateTime date, bool status);
    }
}
