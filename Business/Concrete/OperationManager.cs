using Business.Abstract;
using Business.Contans;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationManager : IOperationService
    {
        private IOperationDal _operationDal;

        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
        }

        public IDataResult<List<OperationClaim>> GetAll() => new SuccessDataResult<List<OperationClaim>>(_operationDal.GetAll(), Messages.OperationListed);
    }
}
