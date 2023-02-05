using Core.Entities;

namespace Entities.Concrete
{
    public class MonetaryDeficit :IEntity
    {
        public int MonetaryDeficitId { get; set; }
        public string NameSurname { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
       
    }
}
