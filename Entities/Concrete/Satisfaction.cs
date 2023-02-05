using Core.Entities;

namespace Entities.Concrete
{
    public class Satisfaction :IEntity
    {
        public int SatisfactionId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerNameSurname { get; set; }
        public string PromissoryNumber { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }

    }
}
