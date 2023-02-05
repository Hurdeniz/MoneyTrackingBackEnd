using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IMoneyOutputService
    {
        IResult Add(MoneyOutput moneyOutput);
        IResult Update(MoneyOutput moneyOutput);
        IResult Delete(MoneyOutput moneyOutput);
        IDataResult<List<MoneyOutput>> GetAllMoneyOutputDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate);
        IDataResult<List<MoneyOutputDetailDto>> GetAllMoneyOutputDetailByDate(DateTime startDate, DateTime endDate);
        IDataResult<List<MoneyOutputDetailDto>> GetAllMoneyOutputDetailByDay(DateTime day);
    }
}
