using Core.Entities;

namespace Entities.DTOs
{
    public class FutureMoneyCancellationGroupByCustomerDto :IDto
    {
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public decimal FutureMoneyCancellationAmount { get; set; }
    }
}
