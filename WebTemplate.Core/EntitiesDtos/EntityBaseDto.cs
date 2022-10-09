namespace WebTemplate.Core.Entities
{
    public abstract class EntityBaseDto: IEntityBaseDto
    {
        public abstract object[] GetKeys();
    }

    public abstract class EntityBaseDto<TKey> : IEntityDto<TKey>
    {
        public TKey Id { get; set; }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
