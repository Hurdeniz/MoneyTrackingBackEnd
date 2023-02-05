using Core.Entities;

namespace Entities.DTOs
{
    public class FutureMoneyCancellationDetailDto :IDto
    {
        public int FutureMoneyCancellationId { get; set; }
        public int FutureMoneyId { get; set; }
        public int UserId { get; set; }
        public decimal FutureMoneyCancellationAmount { get; set; }
        public DateTime FutureMoneyCancellationRegistrationDate { get; set; }
        public string FutureMoneyCancellationDescription { get; set; }     
        public string TypeOfOperation { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public string PromissoryNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal FutureAmount { get; set; }
        public DateTime FutureMoneyRegistrationDate { get; set; }
        public string FutureMoneyDescription { get; set; }
        public bool FutureMoneyStatus { get; set; }

    }
}
