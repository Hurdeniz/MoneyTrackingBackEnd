using Core.Entities;

namespace Entities.DTOs
{
    public class ExpenditureDetailDto :IDto
    {
        public int ExpenditureId { get; set; }
        public int UserId { get; set; }
        public string UserNameSurname { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
