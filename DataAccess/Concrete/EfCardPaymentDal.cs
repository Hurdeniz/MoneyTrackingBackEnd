using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfCardPaymentDal : EfEntityRepositoryBase<CardPayment, MoneyTrackingContext>, ICardPaymentDal
    {
        public List<CardPaymentDetailDto> GetAllCardPaymentDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from c in context.CardPayments
                             join b in context.Banks
                             on c.BankId equals b.BankId
                             join u in context.Users
                             on c.UserId equals u.UserId
                             where c.UserId == userId && c.Date >= startDate && c.Date <= endDate
                             select new CardPaymentDetailDto
                             {
                                 CardPaymentId = c.CardPaymentId,
                                 UserId = u.UserId,
                                 UserNameSurname = $"{u.FirstName} {u.LastName}",
                                 Date = c.Date,
                                 Amount = c.Amount,
                                 Description = c.Description,
                                 BankId = b.BankId,
                                 BankName = b.BankName
                             };
                return result.OrderByDescending(c => c.Date).ThenBy(b => b.BankName).ToList();
            }
        }

        public List<CardPaymentGroupByBankNameDto> GetAllCardPaymentsByDateGroupByBankName(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from c in context.CardPayments
                             join b in context.Banks
                             on c.BankId equals b.BankId
                             where c.Date == date
                             group new { c, b } by b.BankName
                              into g
                             select new CardPaymentGroupByBankNameDto
                             {
                                 BankName = g.Key,
                                 Amount = g.Sum(c => c.c.Amount)
                             };


                return result.OrderBy(b=>b.BankName).ToList();

            }
        }

        public GetCountDto GetCountByDate(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var count = context.CardPayments.Where(d => d.Date == date).Count();
        
                GetCountDto getCountDto = new GetCountDto
                {
                    Count = count
                };
                return getCountDto;

            }
        }

        public GetSumDto GetSumByDateAndUser(DateTime date , int userId)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var sum = context.CardPayments.Where(c => c.Date == date && c.UserId == userId).Sum(c=>c.Amount) ;

                GetSumDto getSumDto = new GetSumDto
                {
                    Sum = sum
                };
                return getSumDto;

            }
        }
    }
}
