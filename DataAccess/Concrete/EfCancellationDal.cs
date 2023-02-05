using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfCancellationDal : EfEntityRepositoryBase<Cancellation, MoneyTrackingContext>, ICancellationDal
    {
        public List<CancellationDetailDto> GetAllCancellationDetailByDate(DateTime startDate, DateTime endDate)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from c in context.Cancellations
                             join u in context.Users
                on c.UserId equals u.UserId
                             where c.Date >= startDate && c.Date <= endDate
                             select new CancellationDetailDto
                             {
                                 CancellationId = c.CancellationId,
                                 UserId = u.UserId,
                                 UserNameSurname = $"{u.FirstName} {u.LastName}",
                                 CustomerCode = c.CustomerCode,
                                 CustomerNameSurname = c.CustomerNameSurname,
                                 PromissoryNumber = c.PromissoryNumber,
                                 TransactionAmount = c.TransactionAmount,
                                 CancellationAmount = c.CancellationAmount,
                                 Date = c.Date,
                                 Description = c.Description
                             };
                return result.OrderByDescending(c => c.Date).ThenBy(c => c.CustomerNameSurname).ToList();
            }
        }

        public GetSumDto GetSumByDateAndUser(DateTime date, int userId)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var sum = context.Cancellations.Where(c => c.Date == date && c.UserId == userId).Sum(c => c.CancellationAmount);

                GetSumDto getSumDto = new GetSumDto
                {
                    Sum = sum
                };
                return getSumDto;

            }
        }

    }
}
