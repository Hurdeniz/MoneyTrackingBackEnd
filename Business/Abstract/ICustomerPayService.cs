using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerPayService
    {
        IDataResult<List<CustomerPay>> GetAllCustomerPayDetailByDate(DateTime startDate, DateTime endDate);
        IResult Add(CustomerPay customerPay);
        IResult Update(CustomerPay customerPay);
        IResult Delete(CustomerPay customerPay);
        
    }
}
