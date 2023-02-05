using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFutureMoneyService
    {
      
        IDataResult<List<FutureMoneyDetailDto>> GetAllFutureMoneyDetailByStatus(bool status);
        IDataResult<List<FutureMoneyDetailDto>> GetAllFutureMoneyDetailByUserIdAndStatus(int userId, bool status);
        IDataResult<List<FutureMoneyGroupByCustomerDto>> GetAllFutureMoneyByDateGroupByCustomer(DateTime date);
        IResult Add(FutureMoney futureMoney);
        IResult Update(FutureMoney futureMoney);
        IResult Delete(FutureMoney futureMoney);
        IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId);
        IResult UpdateFutureMoney(FutureMoney futureMoney);
    }
}
