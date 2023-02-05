using Core.Entities;

namespace Entities.Concrete
{
    public class MoneyOutput :IEntity
    {
        public int MoneyOutputId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
