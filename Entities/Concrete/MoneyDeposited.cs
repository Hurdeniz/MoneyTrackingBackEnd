using Core.Entities;
using System.Security.Cryptography;

namespace Entities.Concrete
{
    public class MoneyDeposited :IEntity
    {
        public int MoneyDepositedId { get; set; }
        public int BankId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
