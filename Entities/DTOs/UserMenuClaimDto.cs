using Core.Entities;

namespace Entities.DTOs
{
    public class UserMenuClaimDto : IDto
    {
        public int UserMenuClaimId { get; set; }
        public int MenuClaimId { get; set; }
        public int UserId { get; set; }
        public string MenuClaimName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
