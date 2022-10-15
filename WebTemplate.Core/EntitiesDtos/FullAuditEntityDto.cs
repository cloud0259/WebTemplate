namespace WebTemplate.Core.Entities
{
    public abstract class FullAuditEntityDto :AuditEntityDto, IFullAuditEntityDto
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class FullAuditEntityDto<TKey> : AuditEntityDto<TKey>, IFullAuditEntityDto<TKey>
    {
        public bool IsDeleted { get; set; }
    }
}
