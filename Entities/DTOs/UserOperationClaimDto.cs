using Core.Entities;

namespace Entities.DTOs
{
    public class UserOperationClaimDto :IDto
    {
        public int UserOperationClaimId { get; set; }
        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
        public string OperationClaimName { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

    }
}
