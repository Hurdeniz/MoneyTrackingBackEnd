using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfFutureMoneyCancellationDal : EfEntityRepositoryBase<FutureMoneyCancellation, MoneyTrackingContext>, IFutureMoneyCancellationDal
    {
        public List<FutureMoneyCancellationDetailDto> GetAllFutureMoneyCancellationDetail()
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from c in context.FutureMoneyCancellations
                             join f in context.FutureMoneys
                             on c.FutureMoneyId equals f.FutureMoneyId
                             select new FutureMoneyCancellationDetailDto
                             {
                                 FutureMoneyCancellationId = c.FutureMoneyCancellationId,
                                 FutureMoneyId = c.FutureMoneyId,
                                 UserId = f.UserId,
                                 FutureMoneyCancellationAmount = c.FutureMoneyCancellationAmount,
                                 FutureMoneyCancellationRegistrationDate = c.FutureMoneyCancellationRegistrationDate,
                                 TypeOfOperation = f.TypeOfOperation,
                                 CustomerCode = f.CustomerCode,
                                 CustomerNameSurname = f.CustomerNameSurname,
                                 FutureMoneyCancellationDescription = c.Description,                               
                                 PromissoryNumber = f.PromissoryNumber,
                                 TransactionAmount = f.TransactionAmount,
                                 AmountPaid = f.AmountPaid,
                                 FutureAmount =f.FutureAmount,                                                        
                                 FutureMoneyRegistrationDate=f.FutureMoneyRegistrationDate,                             
                                 FutureMoneyDescription = f.Description,
                                 FutureMoneyStatus = f.Status


                             };
                return result.OrderByDescending(c => c.FutureMoneyCancellationRegistrationDate).ThenBy(c => c.FutureMoneyCancellationAmount).ToList();

            }
        }

        public List<FutureMoneyCancellationGroupByCustomerDto> GetAllFutureMoneyCancellationByDateGroupByCustomer(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from c in context.FutureMoneyCancellations
                             join f in context.FutureMoneys
                             on c.FutureMoneyId equals f.FutureMoneyId
                             where c.FutureMoneyCancellationRegistrationDate == date
                             group c by new { f.CustomerCode, f.CustomerNameSurname }
                              into g
                             select new FutureMoneyCancellationGroupByCustomerDto
                             {
                                 CustomerCode = g.Key.CustomerCode,
                                 CustomerNameSurname = g.Key.CustomerNameSurname,
                                 FutureMoneyCancellationAmount = g.Sum(c => c.FutureMoneyCancellationAmount)
                             };


                return result.ToList();

            }
        }
    }
}
