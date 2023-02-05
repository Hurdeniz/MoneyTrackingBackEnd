using Core.Entities;

namespace Entities.Concrete
{
    public class StaffTask :IEntity
    {
        public int StaffTaskId { get; set; }
        public string StaffTaskName { get; set; }
    }
}
