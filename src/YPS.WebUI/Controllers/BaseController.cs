using System.Linq;
using  System.Web;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace YPS.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public long UserId => long.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public long SchoolId => long.Parse(User.FindFirst(ClaimTypes.GivenName).Value);
        
    }
}