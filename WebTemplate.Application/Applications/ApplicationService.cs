using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WebTemplate.Infrastructure.DependencyInjection;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Application.Applications
{

    public abstract class ApplicationService : IApplicationService
    {
        public ILazyServiceProvider LazyServiceProvider { get; set; }
        protected ILoggerFactory LoggerFactory => LazyServiceProvider.LazyGetRequiredService<ILoggerFactory>();
        public ILogger Logger => LazyServiceProvider.LazyGetService<ILogger>(provider => LoggerFactory?.CreateLogger(GetType().FullName) ?? NullLogger.Instance);
        public IMapper Mapper => LazyServiceProvider.LazyGetRequiredService<IMapper>();
        public ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

    }
}
