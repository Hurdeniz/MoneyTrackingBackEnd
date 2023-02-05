using Core.Entities;

namespace Entities.Concrete
{
    public class Bank :IEntity
    {
        public int BankId { get; set; }
        public string BankName { get; set; }

    }
}
