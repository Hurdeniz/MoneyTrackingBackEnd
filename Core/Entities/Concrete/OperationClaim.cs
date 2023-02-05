namespace Core.Entities.Concrete
{
    public class OperationClaim :IEntity
    {
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
        public string Description { get; set; }
    }
}
