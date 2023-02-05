using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardPaymentController : ControllerBase
    {
        private ICardPaymentService _cardPaymentService;

        public CardPaymentController(ICardPaymentService cardPaymentService)
        {
            _cardPaymentService = cardPaymentService;
        }

        [HttpGet("GetAllCardPaymentDetailByUserIdAndDate")]
        public IActionResult GetAllCardPaymentDetailByUserIdAndDate(int userId, DateTime startDate , DateTime endDate)
        {
            var result = _cardPaymentService.GetAllCardPaymentDetailByUserIdAndDate(userId,startDate, endDate);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllCardPaymentsByDateGroupByBankName")]
        public IActionResult GetAllCardPaymentsByDateGroupByBankName(DateTime date)
        {
            var result = _cardPaymentService.GetAllCardPaymentsByDateGroupByBankName(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetCountByDate")]
        public IActionResult GetCountByDate(DateTime date)
        {
            var result = _cardPaymentService.GetCountByDate(date);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetSumByDateAndUser")]
        public IActionResult GetSumByDateAndUser(DateTime date , int userId)
        {
            var result = _cardPaymentService.GetSumByDateAndUser(date,userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("Add")]
        public IActionResult Add(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Add(cardPayment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Delete(cardPayment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(CardPayment cardPayment)
        {
            var result = _cardPaymentService.Update(cardPayment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
