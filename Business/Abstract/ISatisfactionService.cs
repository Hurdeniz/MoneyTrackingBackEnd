using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISatisfactionService
    {
        IDataResult<List<Satisfaction>> GetAllSatisfactionDetailByDate(DateTime startDate, DateTime endDate);
        IResult Add(Satisfaction satisfaction);
        IResult Update(Satisfaction satisfaction);
        IResult Delete(Satisfaction satisfaction);
      
       
        
    }
}
