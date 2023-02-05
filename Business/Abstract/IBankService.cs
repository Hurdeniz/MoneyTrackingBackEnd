using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBankService
    {
        IDataResult<List<Bank>> GetAll();
        IResult Add(Bank bank);
        IResult Update(Bank bank);
        IResult Delete(Bank bank);
    }
}
