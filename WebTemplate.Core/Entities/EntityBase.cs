namespace WebTemplate.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public abstract object[] GetKeys();
    }

    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
