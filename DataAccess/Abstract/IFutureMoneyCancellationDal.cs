using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IFutureMoneyCancellationDal : IEntityRepository<FutureMoneyCancellation>
    {
        List<FutureMoneyCancellationGroupByCustomerDto> GetAllFutureMoneyCancellationByDateGroupByCustomer(DateTime date);
        List<FutureMoneyCancellationDetailDto> GetAllFutureMoneyCancellationDetail();
    }
}
