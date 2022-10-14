using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Identity.Services;

namespace WebTemplate.API.Models
{
    public class Authenticate
    {
        /// <summary>
        ///     command
        /// </summary>
        public class AuthenticateCommand : TokenRequest, IRequest<CommandResponse>
        {
        }

        /// <summary>
        ///     Response
        /// </summary>
        public class CommandResponse
        {
            /// <summary>
            ///     Resource
            /// </summary>
            public TokenResponse Resource { get; set; }
        }

        /// <summary>
        ///     Register Validation 
        /// </summary>
        public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
        {

            /// <summary>
            ///     Validator ctor
            /// </summary>
            public AuthenticateCommandValidator()
            {
                RuleFor(x => x.Username)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty();

                RuleFor(x => x.Password)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty();
            }

        }

        /// <summary>
        ///     Handler
        /// </summary>
        public class CommandHandler : IRequestHandler<AuthenticateCommand, CommandResponse>
        {
            private readonly ITokenService _tokenService;
            private readonly IMapper _mapper;
            private readonly HttpContext _httpContext;

            /// <summary>
            ///     ctor
            /// </summary>
            /// <param name="tokenService"></param>
            /// <param name="mapper"></param>
            /// <param name="httpContextAccessor"></param>
            public CommandHandler(ITokenService tokenService,
                                  IMapper mapper,
                                  IHttpContextAccessor httpContextAccessor)
            {
                this._tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                this._httpContext = (httpContextAccessor != null) ? httpContextAccessor.HttpContext : throw new ArgumentNullException(nameof(httpContextAccessor));

            }

            /// <summary>
            ///     Handle
            /// </summary>
            /// <param name="command"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<CommandResponse> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
            {
                CommandResponse response = new CommandResponse();

                string ipAddress = _httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

                TokenResponse tokenResponse = await _tokenService.Authenticate(command, ipAddress);
                if (tokenResponse == null)
                {
                    throw new Exception("Invalid Username and/or Password. Please try again");
                }

                response.Resource = tokenResponse;
                return response;
            }
        }

    }
}
