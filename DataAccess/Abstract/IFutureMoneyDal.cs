using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IFutureMoneyDal : IEntityRepository<FutureMoney>
    {
        List<FutureMoneyDetailDto> FutureMoneyDetailDto(Expression<Func<FutureMoneyDetailDto, bool>> filter = null);
        List<FutureMoneyGroupByCustomerDto> GetAllFutureMoneyByDateGroupByCustomer(DateTime date);
        GetSumDto GetSumByDateAndUser(DateTime date, int userId);
        GetSumDto TotalIncomingMoney(int futureMoneyId);
    }
}
