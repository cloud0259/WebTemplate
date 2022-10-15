using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.DependencyInjection
{
    public  class LazyServiceProvider : ILazyServiceProvider
    {
        protected IServiceProvider ServiceProvider { get; }
        protected ConcurrentDictionary<Type, Lazy<object>> CachedServices { get; }

        public LazyServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            CachedServices = new ConcurrentDictionary<Type, Lazy<object>>();
            CachedServices.TryAdd(typeof(IServiceProvider), new Lazy<object>(() => ServiceProvider));
        }

        public virtual T LazyGetRequiredService<T>()
        {
            return (T)LazyGetRequiredService(typeof(T));
        }

        public virtual object LazyGetRequiredService(Type serviceType)
        {
            return GetService(serviceType);
        }

        public virtual T LazyGetService<T>()
        {
            return (T)LazyGetService(typeof(T));
        }

        public virtual object LazyGetService(Type serviceType)
        {
            return GetService(serviceType);
        }

        public virtual T LazyGetService<T>(T defaultValue)
        {
            return (T)LazyGetService(typeof(T), defaultValue);
        }

        public virtual object LazyGetService(Type serviceType, object defaultValue)
        {
            return LazyGetService(serviceType) ?? defaultValue;
        }

        public virtual T LazyGetService<T>(Func<IServiceProvider, object> factory)
        {
            return (T)LazyGetService(typeof(T), factory);
        }

        public virtual object LazyGetService(Type serviceType, Func<IServiceProvider, object> factory)
        {
            return CachedServices.GetOrAdd(
                serviceType,
                _ => new Lazy<object>(() => factory(ServiceProvider))
            ).Value;
        }

        public virtual object GetService(Type serviceType)
        {
            return CachedServices.GetOrAdd(
                serviceType,
                _ => new Lazy<object>(() => ServiceProvider.GetService(serviceType))
            ).Value;
        }

    }
}
