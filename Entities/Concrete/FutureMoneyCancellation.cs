using Core.Entities;

namespace Entities.Concrete
{
    public class FutureMoneyCancellation :IEntity
    {
        public int FutureMoneyCancellationId { get; set; }
        public int FutureMoneyId { get; set; }
        public decimal FutureMoneyCancellationAmount { get; set; }
        public DateTime FutureMoneyCancellationRegistrationDate { get; set; }
        public string Description { get; set; }


    }
}
