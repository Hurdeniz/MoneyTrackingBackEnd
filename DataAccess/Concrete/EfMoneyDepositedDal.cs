using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfMoneyDepositedDal : EfEntityRepositoryBase<MoneyDeposited, MoneyTrackingContext>, IMoneyDepositedDal
    {
        public List<MoneyDepositedDetailDto> GetAllMoneyDepositedDetailByDate(DateTime startDate, DateTime endDate)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from m in context.MoneyDepositeds
                             join b in context.Banks
                             on m.BankId equals b.BankId
                             where m.Date >= startDate && m.Date <= endDate
                             select new MoneyDepositedDetailDto
                             {
                                 MoneyDepositedId = m.MoneyDepositedId,
                                 BankId = b.BankId,
                                 BankName = b.BankName,
                                 Date = m.Date,
                                 Amount = m.Amount,
                                 Description = m.Description
                             };
                return result.OrderByDescending(m => m.Date).ThenBy(m => m.BankName).ToList();
            }
        }

    }
}
