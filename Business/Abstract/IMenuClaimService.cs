using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IMenuClaimService
    {
        IDataResult<List<MenuClaim>> GetAll();
    }
}
