using Core.Entities;

namespace Entities.DTOs
{
    public class FutureMoneyGroupByCustomerDto :IDto
    {
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public decimal FutureAmount { get; set; }
    }
}
