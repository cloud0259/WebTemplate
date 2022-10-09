namespace WebTemplate.Core.Entities
{
    public abstract class FullAuditEntityDto :AuditEntityDto, IFullAuditEntityDto
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class FullAuditEntityDto<TKey> : AuditEntityDto<TKey>, IFullAuditEntityDto<TKey>
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
