namespace Core.Entities.Concrete
{
    public class MenuClaim :IEntity
    {
        public int MenuClaimId { get; set; }
        public string MenuClaimName { get; set; }
        public string Description { get; set; }
    }
}
