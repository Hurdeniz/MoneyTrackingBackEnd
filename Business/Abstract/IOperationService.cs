using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IOperationService
    {
        IDataResult<List<OperationClaim>> GetAll();
    }
}
