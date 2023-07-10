using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebTemplate.API.Models;
using WebTemplate.API.Mvc;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="mediator"></param>
        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Token/Authenticate
        /// <summary>
        ///     Validate that the user account is valid and return an auth token
        ///     to the requesting app for use in the api.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        [ApiConventionMethod(typeof(WebTemplateApiConventions), nameof(WebTemplateApiConventions.Post))]
        public async Task<TokenResponse> AuthenticateAsync([FromBody] Authenticate.AuthenticateCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Resource!;
        }
    }
}