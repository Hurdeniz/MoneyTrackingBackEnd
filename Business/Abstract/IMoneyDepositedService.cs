using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMoneyDepositedService
    {
        IDataResult<List<MoneyDepositedDetailDto>> GetAllMoneyDepositedDetailByDate(DateTime startDate, DateTime endDate);
        IResult Add(MoneyDeposited moneyDeposited);
        IResult Update(MoneyDeposited moneyDeposited);
        IResult Delete(MoneyDeposited moneyDeposited);
      
    }
}
