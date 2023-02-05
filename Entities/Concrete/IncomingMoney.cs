using Core.Entities;

namespace Entities.Concrete
{
    public class IncomingMoney :IEntity
    {
        public int IncomingMoneyId { get; set; }
        public int FutureMoneyId { get; set; }
        public decimal IncomingAmount { get; set; }
        public DateTime IncomingMoneyRegistrationDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
