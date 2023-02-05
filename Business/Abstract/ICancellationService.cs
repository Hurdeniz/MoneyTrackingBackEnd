using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICancellationService
    {
        IDataResult<List<CancellationDetailDto>> GetAllCancellationDetailByDate(DateTime startDate, DateTime endDate);
        IResult Add(Cancellation cancellation);
        IResult Delete(Cancellation cancellation);
        IResult Update(Cancellation cancellation);
        IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId);
    }
}
