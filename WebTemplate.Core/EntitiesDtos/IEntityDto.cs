using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTemplate.Core.Entities
{
    /// <summary>
    /// Define an entity without id
    /// </summary>
    public interface IEntityBaseDto
    {
        /// <summary>
        ///  Returns an array of ordered keys for this entity.
        /// </summary>
        /// <returns></returns>
        public object[] GetKeys();
    }

    /// <summary>
    /// Define an entity with primary key
    /// </summary>
    /// <typeparam name="TKey">Id object (example: Guid, int ...)</typeparam>
    public interface IEntityDto<TKey> :IEntityBaseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        ///  Unique identifier for this entity
        /// </summary>
        public TKey Id { get; set; }
    }

    /// <summary>
    /// Define a deleted entity without id
    /// </summary>
    public interface IDeleteEntityDto : IEntityBaseDto
    {
        /// <summary>
        /// Use for soft delete object
        /// </summary>
        public bool IsDeleted { get; set; }
    }

    /// <summary>
    /// Define a deleted entity with primary key 
    /// </summary>
    /// <typeparam name="Tkey">Id object (example: Guid, int ...</typeparam>
    public interface IDeleteEntityDto<Tkey>: IEntityDto<Tkey>, IDeleteEntityDto
    {

    }

    /// <summary>
    /// Define an audited entity without id
    /// </summary>
    public interface IAuditEntityDto : IEntityBaseDto
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Creation date of entity
        /// </summary>
        DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Create by User Id
        /// </summary>
        string? CreatedBy { get; set; }
        /// <summary>
        /// Updated date of entity
        /// </summary>
        DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Update by User Id
        /// </summary>
        string? UpdatedBy { get; set; }
    }

    /// <summary>
    /// Define an audited entity without id 
    /// </summary>
    /// <typeparam name="TKey">Id object (example: Guid, int ...</typeparam>
    public interface IAuditEntityDto<TKey>: IAuditEntityDto, IEntityDto<TKey>
    {
        
    }

    /// <summary>
    /// Define an full Audited entity with primary key
    /// </summary>
    public interface IFullAuditEntityDto : IAuditEntityDto, IDeleteEntityDto
    {

    }

    /// <summary>
    /// Define an full Audited entity with primary key 
    /// </summary>
    /// <typeparam name="TKey">Id object (example: Guid, int ...</typeparam>
    public interface IFullAuditEntityDto<TKey>: IAuditEntityDto<TKey>, IDeleteEntityDto<TKey>
    {

    }
}
