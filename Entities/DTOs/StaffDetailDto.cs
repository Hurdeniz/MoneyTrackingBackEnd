using Core.Entities;

namespace Entities.DTOs
{
    public class StaffDetailDto :IDto
    {

        public int StaffId { get; set; }
        public string IdentityNumber { get; set; }
        public string NameSurname { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public int StaffTaskId { get; set; }
        public string StaffTaskName { get; set; }
        public int StaffEpisodeId { get; set; }
        public string StaffEpisodeName { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Adress { get; set; }
        public DateTime DateOfEntryIntoWork { get; set; }
        public DateTime DateOfDismissal { get; set; }
        public bool Status { get; set; }
    }
}
