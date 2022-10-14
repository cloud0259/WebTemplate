namespace WebTemplate.Core.Entities
{
    public abstract class FullAuditEntity : AuditEntity, IFullAuditEntity
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class FullAuditEntity<TKey> : AuditEntity<TKey>, IFullAuditEntity<TKey>
    {
        public bool IsDeleted { get; set; }
    }
}
