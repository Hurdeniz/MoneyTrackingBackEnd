using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICentralPayService
    {
        IDataResult<List<CentralPay>> GetAllCentralPayDetailByDate(DateTime startDate, DateTime endDate);
        IResult Add(CentralPay centralPay);
        IResult Update(CentralPay centralPay);
        IResult Delete(CentralPay centralPay);

    }
}
