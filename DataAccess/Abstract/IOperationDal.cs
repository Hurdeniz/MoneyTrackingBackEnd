using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOperationDal : IEntityRepository<OperationClaim>
    {
    }
}
