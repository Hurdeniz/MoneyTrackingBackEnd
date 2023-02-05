using Core.Entities;

namespace Entities.DTOs
{
    public class GetTotalsDto :IDto
    {
      
        public decimal TotalCancellationAmount { get; set; }
        public decimal TotalCentralPayAmount { get; set; }
        public decimal TotalCustomerPayAmount { get; set; }
        public decimal TotalExpenditureAmount { get; set; }
        public decimal TotalFutureMoneyAmount { get; set; }
        public decimal TotalFutureMoneyCancellationAmount { get; set; }
        public decimal TotalIncomingMoneyAmount { get; set; }
        public decimal TotalMoneyDepositedAmount { get; set; }
        public decimal TotalMoneyOutputAmount { get; set; }
        public decimal Turnover { get; set; }
    }
}
