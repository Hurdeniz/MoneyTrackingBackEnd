using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMonetaryDeficitService
    {
        IDataResult<List<MonetaryDeficit>> GetAll();
        IResult Add(MonetaryDeficit expenditure);
        IResult Update(MonetaryDeficit expenditure);
        IResult Delete(MonetaryDeficit expenditure);
        
    }
}


