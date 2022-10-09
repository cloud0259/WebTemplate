﻿namespace WebTemplate.Core.Entities
{
    public abstract class FullAuditEntity :AuditEntity, IFullAuditEntity
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public abstract class FullAuditEntity<TKey> : AuditEntity<TKey>, IFullAuditEntity<TKey>
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}