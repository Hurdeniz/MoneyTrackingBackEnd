using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class EfMoneyOutputDal : EfEntityRepositoryBase<MoneyOutput, MoneyTrackingContext>, IMoneyOutputDal
    {
        public List<MoneyOutputDetailDto> MoneyOutputDetailDto(Expression<Func<MoneyOutputDetailDto, bool>> filter = null)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from m in context.MoneyOutputs
                             join u in context.Users
                             on m.UserId equals u.UserId
                             select new MoneyOutputDetailDto
                             {
                                 MoneyOutputId = m.MoneyOutputId,
                                 UserId = u.UserId,
                                 UserNameSurname = $"{u.FirstName} {u.LastName}",
                                 Date = m.Date,
                                 TotalAmount = m.TotalAmount,
                                 Description = m.Description
                             };

                return filter == null ? result.OrderByDescending(m => m.Date).ToList() : result.OrderByDescending(m => m.Date).Where(filter).ToList();

            }
        }
    }
}
