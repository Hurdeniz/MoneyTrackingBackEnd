using Core.Entities;

namespace Entities.Concrete
{
    public class SafeBox :IEntity
    {
        public int SafeBoxId { get; set; }
        public decimal TotalMoneyOutputAmount { get; set; }
        public decimal TotalCancellationAmount { get; set; }
        public decimal TotalFutureMoneyAmount { get; set; }
        public decimal TotalFutureMoneyCancellationAmount { get; set; }
        public decimal TotalIncomingMoneyAmount { get; set; }
        public decimal TotalCentralPayAmount { get; set; }
        public decimal TotalCustomerPayAmount { get; set; }
        public decimal TotalMonetaryDepositedAmount { get; set; }
        public decimal TotalSafeBoxAmount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
