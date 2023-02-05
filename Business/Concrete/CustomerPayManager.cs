using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerPayManager : ICustomerPayService
    {
        private ICustomerPayDal _customerPayDal;

        public CustomerPayManager(ICustomerPayDal customerPayDal)
        {
            _customerPayDal = customerPayDal;
        }

        [SecuredOperation("Admin,CustomerPay.GetAllCustomerPayDetailByDate")]
        [CacheAspect]
        public IDataResult<List<CustomerPay>> GetAllCustomerPayDetailByDate(DateTime startDate, DateTime endDate) => new SuccessDataResult<List<CustomerPay>>(_customerPayDal.GetAll(c => c.Date >= startDate && c.Date <= endDate).OrderByDescending(c => c.Date).ThenBy(c => c.CustomerName).ThenBy(c => c.Amount).ToList(), Messages.CustomerPayListed);

        [SecuredOperation("Admin,CustomerPay.Add")]
        [CacheRemoveAspect("ICustomerPayService.Get")]
        [ValidationAspect(typeof(CustomerPayValidator))]
        public IResult Add(CustomerPay customerPay)
        {
            _customerPayDal.Add(customerPay);
            return new SuccessResult(Messages.CustomerPayAdded);
        }

        [SecuredOperation("Admin,CustomerPay.Update")]
        [CacheRemoveAspect("ICustomerPayService.Get")]
        [ValidationAspect(typeof(CustomerPayValidator))]
        public IResult Update(CustomerPay customerPay)
        {
            _customerPayDal.Update(customerPay);
            return new SuccessResult(Messages.CustomerPayUpdated);
        }

        [SecuredOperation("Admin,CustomerPay.Delete")]
        [CacheRemoveAspect("ICustomerPayService.Get")]
        public IResult Delete(CustomerPay customerPay)
        {
            _customerPayDal.Delete(customerPay);
            return new SuccessResult(Messages.CustomerPayDeleted);
        }


    }
}
