using Core.Entities;

namespace Entities.DTOs
{
    public class ShipmentListDetailDto :IDto
    {
        public int ShipmentListId { get; set; }
        public int UserId { get; set; }
        public string UserNameSurname { get; set; }
        public string ShipmentNumber { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public string PromissoryNumber { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
