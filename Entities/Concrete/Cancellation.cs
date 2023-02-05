using Core.Entities;

namespace Entities.Concrete
{
    public class Cancellation :IEntity
    {
        public int CancellationId { get; set; }
        public int UserId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public string PromissoryNumber { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal CancellationAmount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
