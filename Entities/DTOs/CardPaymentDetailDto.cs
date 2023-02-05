using Core.Entities;

namespace Entities.DTOs
{
    public class CardPaymentDetailDto :IDto
    {
        public int CardPaymentId { get; set; }
        public int UserId { get; set; }
        public string UserNameSurname { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
