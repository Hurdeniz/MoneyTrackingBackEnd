using Core.Entities;

namespace Entities.DTOs
{
    public class IncomingMoneyGroupByCustomerDto :IDto
    {
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public decimal IncomingAmount { get; set; }
      
    }
}
