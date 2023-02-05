using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICancellationDal : IEntityRepository<Cancellation>
    {
        List<CancellationDetailDto> GetAllCancellationDetailByDate(DateTime startDate, DateTime endDate);
        GetSumDto GetSumByDateAndUser(DateTime date, int userId);
    }
}
