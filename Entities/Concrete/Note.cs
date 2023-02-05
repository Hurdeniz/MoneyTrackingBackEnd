using Core.Entities;

namespace Entities.Concrete
{
    public class Note :IEntity
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
     
    }
}
