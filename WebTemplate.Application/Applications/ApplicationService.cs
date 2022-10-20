using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WebTemplate.Infrastructure.DependencyInjection;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Application.Applications
{

    public abstract class ApplicationService : IApplicationService
    {

        public ILazyServiceProvider LazyServiceLoader { get; set; }
        protected ILoggerFactory LoggerFactory => LazyServiceLoader.LazyGetRequiredService<ILoggerFactory>();
        public ILogger Logger => LazyServiceLoader.LazyGetService<ILogger>(provider => LoggerFactory?.CreateLogger(GetType().FullName) ?? NullLogger.Instance);
        public IMapper Mapper => LazyServiceLoader.LazyGetRequiredService<IMapper>();
        public ICurrentUser CurrentUser => LazyServiceLoader.LazyGetRequiredService<ICurrentUser>();

    }
}
