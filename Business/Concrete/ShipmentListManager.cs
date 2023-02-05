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
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ShipmentListManager : IShipmentListService
    {
        private IShipmentListDal _shipmentListDal;

        public ShipmentListManager(IShipmentListDal shipmentListDal)
        {
            _shipmentListDal = shipmentListDal;
        }

        [SecuredOperation("Admin,Staff,Service,ShipmentList.GetAllShipmentListDetailByStatusAndDate")]
        [CacheAspect]
        public IDataResult<List<ShipmentListDetailDto>> GetAllShipmentListDetailByStatusAndDate(bool status, DateTime startDate, DateTime endDate)
        {

            if (status == true)
            {
                return new SuccessDataResult<List<ShipmentListDetailDto>>(_shipmentListDal.GetAllShipmentListDetailByStatusAndDate(status, startDate, endDate), Messages.ShipmentListListed);
            }
            else
            {
                return new SuccessDataResult<List<ShipmentListDetailDto>>(_shipmentListDal.GetAllShipmentListDetailByStatusAndDate(status, startDate, endDate), Messages.ResearchListListed);
            }

        }

        [CacheAspect]
        public IDataResult<GetCountDto> GetCountByDate(DateTime date, bool status)
        {
            if (status == true)
            {
                return new SuccessDataResult<GetCountDto>(_shipmentListDal.GetCountByDate(date, status), Messages.ShipmentListCount);
            }
            else
            {
                return new SuccessDataResult<GetCountDto>(_shipmentListDal.GetCountByDate(date, status), Messages.ResearchListCount);
            }
        }

        [SecuredOperation("Admin,Staff,Service,ShipmentList.Add")]
        [CacheRemoveAspect("IShipmentListService.Get")]
        [ValidationAspect(typeof(ShipmentListValidator))]
        public IResult Add(ShipmentList shipmentList)
        {
           
            _shipmentListDal.Add(shipmentList);
            return new SuccessResult(Messages.ShipmentListAdded);
        }

        [SecuredOperation("Admin,Staff,Service,ShipmentList.Update")]
        [CacheRemoveAspect("IShipmentListService.Get")]
        [ValidationAspect(typeof(ShipmentListValidator))]
        public IResult Update(ShipmentList shipmentList)
        {
            _shipmentListDal.Update(shipmentList);
            return new SuccessResult(Messages.ShipmentListUpdated);
        }

        [SecuredOperation("Admin,Staff,Service,ShipmentList.Delete")]
        [CacheRemoveAspect("IShipmentListService.Get")]
        public IResult Delete(ShipmentList shipmentList)
        {
            _shipmentListDal.Delete(shipmentList);
            return new SuccessResult(Messages.ShipmentListDeleted);
        }
    }
}
