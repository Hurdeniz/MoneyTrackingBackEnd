using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICardPaymentDal : IEntityRepository<CardPayment>
    {
        GetCountDto GetCountByDate(DateTime date);
        List<CardPaymentDetailDto> GetAllCardPaymentDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate);
        List<CardPaymentGroupByBankNameDto> GetAllCardPaymentsByDateGroupByBankName(DateTime date);
        GetSumDto GetSumByDateAndUser(DateTime date, int userId);
    }
}
