using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ISafeBoxDal : IEntityRepository<SafeBox>
    {
        GetCountDto GetSafeBoxCountByDate(DateTime date);
        GetTotalsDto TotalsByDay(DateTime date);
    }
}
