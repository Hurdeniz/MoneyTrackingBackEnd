using Core.Entities;

namespace Entities.DTOs
{
    public class CardPaymentGroupByBankNameDto :IDto
    {
        public string BankName { get; set; }
        public decimal Amount { get; set; }
    }
}
