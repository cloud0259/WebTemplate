using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTemplate.Core.Entities
{
    /// <summary>
    /// Define an entity without id
    /// </summary>
    public interface IEntityBase
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
    public interface IEntityBase<TKey> :IEntityBase
    {
        /// <summary>
        ///  Unique identifier for this entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; }
    }

    /// <summary>
    /// Define a deleted entity without id
    /// </summary>
    public interface IDeleteEntity : IEntityBase
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
    public interface IDeleteEntity<Tkey>: IEntityBase<Tkey>, IDeleteEntity
    {

    }

    /// <summary>
    /// Define an audited entity without id
    /// </summary>
    public interface IAuditEntity : IEntityBase
    {

        /// <summary>
        /// Creation date of entity
        /// </summary>       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    public interface IAuditEntity<TKey>: IAuditEntity, IEntityBase<TKey>
    {
        
    }

    /// <summary>
    /// Define an full Audited entity with primary key
    /// </summary>
    public interface IFullAuditEntity : IAuditEntity, IDeleteEntity
    {

    }

    /// <summary>
    /// Define an full Audited entity with primary key 
    /// </summary>
    /// <typeparam name="TKey">Id object (example: Guid, int ...</typeparam>
    public interface IFullAuditEntity<TKey>: IAuditEntity<TKey>, IDeleteEntity<TKey>
    {

    }
}
