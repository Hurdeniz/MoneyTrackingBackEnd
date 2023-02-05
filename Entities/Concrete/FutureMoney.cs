using Core.Entities;

namespace Entities.Concrete
{
    public class FutureMoney :IEntity
    {
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
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
