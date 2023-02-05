using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IExpenditureDal : IEntityRepository<Expenditure>
    {
        List<ExpenditureDetailDto> GetAllExpenditureDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate);
        GetSumDto GetSumByDateAndUser(DateTime date, int userId);
    }
}
