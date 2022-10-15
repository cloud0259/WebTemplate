namespace WebTemplate.Core.Entities
{
    public abstract class AuditEntityDto :EntityBaseDto, IAuditEntityDto
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }

    public abstract class AuditEntityDto<TKey> :EntityBaseDto<TKey>, IAuditEntityDto<TKey>
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }    
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
