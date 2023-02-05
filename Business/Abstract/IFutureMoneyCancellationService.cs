using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFutureMoneyCancellationService
    {
        IResult AddFutureMoneyCancellationUpdateFutureMoney(FutureMoneyCancellationDetailDto futureMoneyCancellationDetailDto);
        IResult DeleteFutureMoneyCancellationUpdateFutureMoney(FutureMoneyCancellationDetailDto futureMoneyCancellationDetailDto);
        IDataResult<List<FutureMoneyCancellationGroupByCustomerDto>> GetAllFutureMoneyCancellationByDateGroupByCustomer(DateTime date);
        IDataResult<List<FutureMoneyCancellationDetailDto>> GetAllFutureMoneyCancellationDetail();
    }
}
