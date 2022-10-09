namespace WebTemplate.Core.Entities
{
    public abstract class AuditEntity :EntityBase, IAuditEntity
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }

    public abstract class AuditEntity<TKey> :EntityBase<TKey>, IAuditEntity<TKey>
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }    
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public TKey Id { get; set; }
    }
}
