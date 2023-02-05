using Core.Entities;

namespace Entities.Concrete
{
    public class Expenditure :IEntity
    {
        public int ExpenditureId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
