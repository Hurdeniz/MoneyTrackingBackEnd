namespace Core.Entities.Concrete
{
    public class UserMenuClaim :IEntity
    {
        public int UserMenuClaimId { get; set; }
        public int UserId { get; set; }
        public int MenuClaimId { get; set; }
        public bool Status { get; set; }

    }
}
