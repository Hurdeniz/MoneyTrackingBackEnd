using Core.Entities;

namespace Entities.DTOs
{
    public class MoneyDepositedDetailDto :IDto
    {
        public int MoneyDepositedId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
