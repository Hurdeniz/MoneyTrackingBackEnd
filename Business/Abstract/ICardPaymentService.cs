using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICardPaymentService
    {
        IDataResult<GetCountDto> GetCountByDate(DateTime date);
        IDataResult<List<CardPaymentDetailDto>> GetAllCardPaymentDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate);
        IDataResult<List<CardPaymentGroupByBankNameDto>> GetAllCardPaymentsByDateGroupByBankName(DateTime date);
        IResult Add(CardPayment cardPayment);
        IResult Update(CardPayment cardPayment);
        IResult Delete(CardPayment cardPayment);
        IDataResult<GetSumDto> GetSumByDateAndUser(DateTime date, int userId);
    }
}
