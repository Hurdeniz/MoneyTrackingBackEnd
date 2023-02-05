using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BankManager : IBankService
    {
        private IBankDal _bankDal;

        public BankManager(IBankDal bankDal)
        {
            _bankDal = bankDal;
        }

        [CacheAspect]
        [SecuredOperation("Admin,Bank.GetAll")]
        public IDataResult<List<Bank>> GetAll() => new SuccessDataResult<List<Bank>>(_bankDal.GetAll(), Messages.BankListed);

        [CacheRemoveAspect("IBankService.Get")]
        [SecuredOperation("Admin,Bank.Add")]
        [ValidationAspect(typeof(BankValidator))]
        public IResult Add(Bank bank)
        {
            IResult result = BusinessRules.Run(
             CheckIfBankNameExists(bank.BankName));

            if (result != null)
            {
                return result;
            }

            _bankDal.Add(bank);
            return new SuccessResult(Messages.BankAdded);
        }

        [CacheRemoveAspect("IBankService.Get")]
        [SecuredOperation("Admin,Bank.Update")]
        [ValidationAspect(typeof(BankValidator))]
        public IResult Update(Bank bank)
        {
            IResult result = BusinessRules.Run(
            CheckIfBankNameExists(bank.BankName));

            if (result != null)
            {
                return result;
            }

            _bankDal.Update(bank);
            return new SuccessResult(Messages.BankUpdated);
        }

        [CacheRemoveAspect("IBankService.Get")]
        [SecuredOperation("Admin,Bank.Delete")]
        public IResult Delete(Bank bank)
        {
            _bankDal.Delete(bank);
            return new SuccessResult(Messages.BankDeleted);
        }



        private IResult CheckIfBankNameExists(string bankName)
        {
            var result = _bankDal.GetAll(b => b.BankName == bankName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BankNameAlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
