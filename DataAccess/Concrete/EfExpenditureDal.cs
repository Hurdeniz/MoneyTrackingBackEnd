using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfExpenditureDal : EfEntityRepositoryBase<Expenditure, MoneyTrackingContext>, IExpenditureDal
    {

        public List<ExpenditureDetailDto> GetAllExpenditureDetailByUserIdAndDate(int userId, DateTime startDate, DateTime endDate)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var result = from e in context.Expenditures
                             join u in context.Users
                             on e.UserId equals u.UserId
                             where e.UserId == userId && e.Date >= startDate && e.Date <= endDate
                             select new ExpenditureDetailDto
                             {
                                 ExpenditureId = e.ExpenditureId,
                                 UserId = u.UserId,
                                 UserNameSurname = $"{u.FirstName} {u.LastName}",
                                 Date = e.Date,
                                 Amount = e.Amount,
                                 Description = e.Description
                             };
                return result.OrderByDescending(e => e.Date).ThenBy(e => e.Amount).ToList();
            }
        }

        public GetSumDto GetSumByDateAndUser(DateTime date, int userId)
        {
            using (MoneyTrackingContext context = new MoneyTrackingContext())
            {
                var sum = context.Expenditures.Where(c => c.Date == date && c.UserId == userId).Sum(c => c.Amount);

                GetSumDto getSumDto = new GetSumDto
                {
                    Sum = sum
                };
                return getSumDto;

            }
        }

    }
}
