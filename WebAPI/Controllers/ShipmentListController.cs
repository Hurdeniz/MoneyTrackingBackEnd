using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentListController : ControllerBase
    {
        private IShipmentListService _shipmentListService;

        public ShipmentListController(IShipmentListService shipmentListService)
        {
            _shipmentListService = shipmentListService;
        }

        [HttpGet("GetAllShipmentListDetailByStatusAndDate")]
        public IActionResult GetAllShipmentListDetailByStatusAndDate(bool status, DateTime startDate, DateTime endDate)
        {
            var result = _shipmentListService.GetAllShipmentListDetailByStatusAndDate(status,startDate,endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetCountByDate")]
        public IActionResult GetCountByDate(DateTime date , bool status)
        {
            var result = _shipmentListService.GetCountByDate(date,status);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(ShipmentList shipmentList)
        {
            var result = _shipmentListService.Add(shipmentList);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(ShipmentList shipmentList)
        {
            var result = _shipmentListService.Delete(shipmentList);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(ShipmentList shipmentList)
        {
            var result = _shipmentListService.Update(shipmentList);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
