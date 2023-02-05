using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IShipmentListService
    {
        IDataResult<List<ShipmentListDetailDto>> GetAllShipmentListDetailByStatusAndDate(bool status, DateTime startDate, DateTime endDate);
        IResult Add(ShipmentList shipmentList);
        IResult Update(ShipmentList shipmentList);
        IResult Delete(ShipmentList shipmentList);
        IDataResult<GetCountDto> GetCountByDate(DateTime date, bool status);
    }
}
