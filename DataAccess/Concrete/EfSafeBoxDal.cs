using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfSafeBoxDal : EfEntityRepositoryBase<SafeBox, MoneyTrackingContext>, ISafeBoxDal
    {

        public GetTotalsDto TotalsByDay(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var totalCancellationAmount = context.Cancellations.Where(d => d.Date == date).Select(c => c.CancellationAmount).Sum();
                var totalCentralPayAmount = context.CentralPayouts.Where(d => d.Date == date).Select(c => c.Amount).Sum();
                var totalCustomerPayAmount = context.CustomerPayouts.Where(d => d.Date == date).Select(c => c.Amount).Sum();
                var totalExpenditureAmount = context.Expenditures.Where(d => d.Date == date).Select(e => e.Amount).Sum();
                var totalFutureMoneyAmount = context.FutureMoneys.Where(d => d.FutureMoneyRegistrationDate == date && d.Status == true).Select(f => f.FutureAmount).Sum();
                var totalFutureMoneyCancellationAmount = context.FutureMoneyCancellations.Where(d => d.FutureMoneyCancellationRegistrationDate == date).Select(f => f.FutureMoneyCancellationAmount).Sum();
                var totalIncomingMoneyAmount = context.IncomingMoneys.Where(d => d.IncomingMoneyRegistrationDate == date).Select(i => i.IncomingAmount).Sum();
                var totalMoneyDepositedAmount = context.MoneyDepositeds.Where(d => d.Date == date).Select(m => m.Amount).Sum();
                var totalMoneyOutputAmount = context.MoneyOutputs.Where(d => d.Date == date).Select(m => m.TotalAmount).Sum();
                var turnover = context.SafeBoxes.Where(d => d.Date == date.AddDays(-1)).Select(s => s.TotalSafeBoxAmount).Sum();


                GetTotalsDto getSumsDto = new GetTotalsDto
                {
                    TotalCancellationAmount = totalCancellationAmount,
                    TotalCentralPayAmount = totalCentralPayAmount,
                    TotalCustomerPayAmount = totalCustomerPayAmount,
                    TotalExpenditureAmount = totalExpenditureAmount,
                    TotalFutureMoneyAmount = totalFutureMoneyAmount,
                    TotalFutureMoneyCancellationAmount = totalFutureMoneyCancellationAmount,
                    TotalIncomingMoneyAmount = totalIncomingMoneyAmount,
                    TotalMoneyDepositedAmount = totalMoneyDepositedAmount,
                    TotalMoneyOutputAmount = totalMoneyOutputAmount,
                    Turnover = turnover,
                };

                return getSumsDto;

            }
        }


        public GetCountDto GetSafeBoxCountByDate(DateTime date)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
              
                var safeBoxCount = context.SafeBoxes.Where(d => d.Date == date).ToList().Count();


                GetCountDto getCountDto = new GetCountDto
                {
                    Count=safeBoxCount
                };

                return getCountDto;

            }
        }


    }
}
