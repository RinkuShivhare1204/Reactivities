using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator; //private- this can only be used inside this specific class

        protected IMediator Mediator => _mediator ??= //protected- this can be used inside this class and any derived classes 
            HttpContext.RequestServices.GetService<IMediator>();
    }
}