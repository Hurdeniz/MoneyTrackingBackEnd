using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IIncomingMoneyDal : IEntityRepository<IncomingMoney>
    {
        List<IncomingMoneyGroupByCustomerDto> GetAllIncomingMoneyByDateGroupByCustomer(DateTime date);
        List<IncomingMoneyDetailDto> GetAllIncomingMoneyDetail();
    }
}
