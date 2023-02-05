using Core.Entities;

namespace Entities.DTOs
{
    public class MoneyOutputDetailDto :IDto
    {
        public int MoneyOutputId { get; set; }
        public int UserId { get; set; }
        public string UserNameSurname { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
