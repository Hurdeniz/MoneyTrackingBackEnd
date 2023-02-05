using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ISafeBoxService
    {
        IResult Add(SafeBox safeBox);
        IResult Delete(SafeBox safeBox);
        IDataResult<List<SafeBox>> GetAllSafeBoxByDate(DateTime startDate, DateTime endDate);
        IDataResult<GetCountDto> GetSafeBoxCountByDate(DateTime date);
        IDataResult<GetTotalsDto> TotalsByDay(DateTime date);
        IResult Update(SafeBox safeBox);
    }
}
