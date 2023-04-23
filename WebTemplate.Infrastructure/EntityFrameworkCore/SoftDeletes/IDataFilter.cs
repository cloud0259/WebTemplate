namespace WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes
{
    public interface IDataFilter<TFilter> where TFilter : class
    {
        bool IsEnabled { get; }

        public IDisposable Disable();
        public IDisposable Enable();
    }

    public interface IDataFilter
    {
        public IDisposable Disable<TFilter>() where TFilter : class;
        public IDisposable Enable<TFilter>() where TFilter : class;
        bool IsEnabled<TFilter>() where TFilter : class;
    }
}
