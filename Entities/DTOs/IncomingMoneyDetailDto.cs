using Core.Entities;

namespace Entities.DTOs
{
    public class IncomingMoneyDetailDto :IDto
    {
        public int IncomingMoneyId { get; set; }
        public int FutureMoneyId { get; set; }
        public int UserId { get; set; }
        public string TypeOfOperation { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public string PromissoryNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal FutureAmount { get; set; }
        public DateTime FutureMoneyRegistrationDate { get; set; }
        public decimal IncomingAmount { get; set; }
        public DateTime IncomingMoneyRegistrationDate { get; set; }
        public string InComingMoneyDescription { get; set; }
        public string FutureMoneyDescription { get; set; }
        public bool FutureMoneyStatus { get; set; }
        public bool IncomingMoneyStatus { get; set; }


    }

}
