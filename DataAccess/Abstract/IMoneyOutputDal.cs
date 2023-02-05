using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IMoneyOutputDal : IEntityRepository<MoneyOutput>
    {
        List<MoneyOutputDetailDto> MoneyOutputDetailDto(Expression<Func<MoneyOutputDetailDto, bool>> filter = null);
    }
}
