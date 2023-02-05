using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IIncomingMoneyService
    {
        IDataResult<List<IncomingMoneyGroupByCustomerDto>> GetAllIncomingMoneyByDateGroupByCustomer(DateTime date);
        IDataResult<List<IncomingMoneyDetailDto>> GetAllIncomingMoneyDetail();
        IResult AddIncomingMoneyUpdateFutureMoney(IncomingMoneyDetailDto incomingMoneyDetailDto);
        IResult DeleteIncomingMoneyUpdateFutureMoney(IncomingMoneyDetailDto incomingMoneyDetailDto);
     
    }
}
