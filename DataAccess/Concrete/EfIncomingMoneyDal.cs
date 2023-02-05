using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfIncomingMoneyDal : EfEntityRepositoryBase<IncomingMoney, MoneyTrackingContext>, IIncomingMoneyDal
    {

        public List<IncomingMoneyDetailDto> GetAllIncomingMoneyDetail()
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from i in context.IncomingMoneys
                             join f in context.FutureMoneys
                             on i.FutureMoneyId equals f.FutureMoneyId
                             select new IncomingMoneyDetailDto
                             {
                                 IncomingMoneyId = i.IncomingMoneyId,
                                 FutureMoneyId = i.FutureMoneyId,
                                 UserId = f.UserId,
                                 TypeOfOperation = f.TypeOfOperation,
                                 CustomerCode = f.CustomerCode,
                                 CustomerNameSurname = f.CustomerNameSurname,
                                 PromissoryNumber = f.PromissoryNumber,
                                 TransactionAmount = f.TransactionAmount,
                                 AmountPaid = f.AmountPaid,
                                 FutureAmount = f.FutureAmount,
                                 FutureMoneyRegistrationDate = f.FutureMoneyRegistrationDate,
                                 IncomingAmount = i.IncomingAmount,
                                 IncomingMoneyRegistrationDate = i.IncomingMoneyRegistrationDate,
                                 InComingMoneyDescription = i.Description,
                                 FutureMoneyDescription = f.Description,
                                 FutureMoneyStatus = f.Status,
                                 IncomingMoneyStatus=i.Status,
                             };
                return result.OrderByDescending(i => i.IncomingMoneyRegistrationDate).ThenByDescending(i => i.FutureMoneyRegistrationDate).ThenBy(i => i.CustomerNameSurname).ToList();

            }
        }


        public List<IncomingMoneyGroupByCustomerDto> GetAllIncomingMoneyByDateGroupByCustomer(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from i in context.IncomingMoneys
                             join f in context.FutureMoneys
                             on i.FutureMoneyId equals f.FutureMoneyId
                             where i.IncomingMoneyRegistrationDate == date
                             group i by new { f.CustomerCode, f.CustomerNameSurname }
                              into g
                             select new IncomingMoneyGroupByCustomerDto
                             {
                                 CustomerCode = g.Key.CustomerCode,
                                 CustomerNameSurname = g.Key.CustomerNameSurname,
                                 IncomingAmount = g.Sum(c => c.IncomingAmount)
                             };


                return result.ToList();

            }
        }

      
    }
}


