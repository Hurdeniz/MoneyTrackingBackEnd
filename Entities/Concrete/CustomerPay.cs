using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerPay :IEntity
    {
        public int CustomerPayId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }     
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
