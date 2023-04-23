namespace WebTemplate.Core.Entities
{
    /// <summary>
    /// Define a deleted entity without id
    /// </summary>
    public interface ISoftDelete : IEntityBase
    {
        /// <summary>
        /// Use for soft delete object
        /// </summary>
        public bool IsDeleted { get; set; }
    }

    public interface ISoftDelete<TKey> : IEntityBase<TKey> ,ISoftDelete
    { 
    }


}
