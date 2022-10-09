using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Domain.Entities
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
    public interface IEntity<TKey> :IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        ///  Unique identifier for this entity
        /// </summary>
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
    public interface IDeleteEntity<Tkey>: IEntity<Tkey>, IDeleteEntity
    {

    }

    /// <summary>
    /// Define an audited entity without id
    /// </summary>
    public interface IAuditEntity : IEntityBase
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
    public interface IAuditEntity<TKey>: IAuditEntity, IEntity<TKey>
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
