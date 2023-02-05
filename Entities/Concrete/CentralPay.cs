using Core.Entities;

namespace Entities.Concrete
{
    public class CentralPay :IEntity
    {
        public int CentralPayId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
