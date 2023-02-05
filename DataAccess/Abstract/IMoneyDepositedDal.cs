using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IMoneyDepositedDal : IEntityRepository<MoneyDeposited>
    {
        List<MoneyDepositedDetailDto> GetAllMoneyDepositedDetailByDate(DateTime startDate, DateTime endDate);
    }
}
