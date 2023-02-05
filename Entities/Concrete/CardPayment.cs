using Core.Entities;

namespace Entities.Concrete
{
    public class CardPayment:IEntity
    {
        public int CardPaymentId { get; set; }
        public int BankId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
