using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IExpenditureService
    {

        IDataResult<List<ExpenditureDetailDto>> GetAllExpenditureDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate);
        IResult Add(Expenditure expenditure);
        IResult Update(Expenditure expenditure);
        IResult Delete(Expenditure expenditure);
        IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId);
    }
}
