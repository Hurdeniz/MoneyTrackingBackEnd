using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfFutureMoneyDal : EfEntityRepositoryBase<FutureMoney, MoneyTrackingContext>, IFutureMoneyDal
    {
        public List<FutureMoneyDetailDto> FutureMoneyDetailDto(Expression<Func<FutureMoneyDetailDto, bool>> filter = null)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from f in context.FutureMoneys
                             join u in context.Users
                             on f.UserId equals u.UserId

                             select new FutureMoneyDetailDto
                             {
                                 FutureMoneyId = f.FutureMoneyId,
                                 UserId = u.UserId,
                                 UserNameSurname = $"{u.FirstName} {u.LastName}",
                                 TypeOfOperation = f.TypeOfOperation,
                                 CustomerCode = f.CustomerCode,
                                 CustomerNameSurname = f.CustomerNameSurname,
                                 PromissoryNumber = f.PromissoryNumber,
                                 TransactionAmount = f.TransactionAmount,
                                 AmountPaid = f.AmountPaid,
                                 FutureAmount = f.FutureAmount,
                                 FutureMoneyRegistrationDate = f.FutureMoneyRegistrationDate,
                                 Description = f.Description,
                                 Status = f.Status,
                             };
                return filter == null ? result.OrderByDescending(f => f.FutureMoneyRegistrationDate).ThenBy(f => f.CustomerNameSurname).ToList() : result.OrderByDescending(f => f.FutureMoneyRegistrationDate).ThenBy(f => f.CustomerNameSurname).Where(filter).ToList();
            }

        }

        public List<FutureMoneyGroupByCustomerDto> GetAllFutureMoneyByDateGroupByCustomer(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from f in context.FutureMoneys
                             where f.FutureMoneyRegistrationDate == date && f.Status == true
                             group f by new { f.CustomerCode , f.CustomerNameSurname }
                              into g
                             select new FutureMoneyGroupByCustomerDto
                             {
                                 CustomerCode = g.Key.CustomerCode,
                                 CustomerNameSurname = g.Key.CustomerNameSurname,
                                 FutureAmount = g.Sum(f => f.FutureAmount)
                             };


                return result.ToList();

            }
        }


        public GetSumDto TotalIncomingMoney(int futureMoneyId)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var totalIncomingMoneyAmount = context.IncomingMoneys.Where(i => i.FutureMoneyId==futureMoneyId).Select(i =>i.IncomingAmount).Sum();

                GetSumDto getSumDto = new GetSumDto
                {
                    Sum = totalIncomingMoneyAmount,
                };
                return getSumDto;         

            }
        }

        public GetSumDto GetSumByDateAndUser(DateTime date, int userId)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var sum = context.FutureMoneys.Where(c => c.FutureMoneyRegistrationDate == date && c.UserId == userId).Sum(c => c.FutureAmount);

                GetSumDto getSumDto = new GetSumDto
                {
                    Sum = sum
                };
                return getSumDto;

            }
        }

    }
}
