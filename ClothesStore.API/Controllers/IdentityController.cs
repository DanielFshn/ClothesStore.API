using ClothesStrore.Application.User.CreaeteUser;
using ClothesStrore.Application.User.GetAllUsers;
using ClothesStrore.Application.User.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IMediator _mediator { get; }

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] CreateUserRequest payload)
        {
            var userCreated = await _mediator.Send(payload);
            if (userCreated != null)
                return Ok(userCreated);
            else
                return BadRequest();
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("getAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var response = await _mediator.Send(new GetAllUsersRequest(),HttpContext.RequestAborted);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequest paylaod)
        {
            var response = await _mediator.Send(paylaod);
            return Ok(response);
        }
    }
}
