using ClothesStore.API.Common;
using ClothesStrore.Application.User.ChangePassword;
using ClothesStrore.Application.User.CreaeteUser;
using ClothesStrore.Application.User.ForgotPassword;
using ClothesStrore.Application.User.GetAllUsers;
using ClothesStrore.Application.User.LoginUser;
using ClothesStrore.Application.User.ResetPasswordWithToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Tnef;

namespace ClothesStore.API.Controllers;

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
        var response = await _mediator.Send(new GetAllUsersRequest(), HttpContext.RequestAborted);
        return Ok(response);
    }
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginUserRequest paylaod)
    {
        var response = await _mediator.Send(paylaod);
        return Ok(response);
    }
    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequest model)
    {
        var command = new ChangePasswordRequest
        {
            Id = id,
            CurrentPassword = model.CurrentPassword,
            NewPassword = model.NewPassword,
            RepeatPassword = model.RepeatPassword
        };
        var result = await _mediator.Send(command);
        var jsonObject = Deserialize.JsonDeserialize(result);
        jsonObject.TryGetValue("Message", out string messageValue);

        if (bool.Parse(messageValue))
            return Ok(jsonObject);
        else
            return BadRequest(jsonObject);
    }
    [HttpPost("forgot-password")]
    public async Task<ActionResult> ForgotPassword([FromBody] EmailSendRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("reset-password")]
    public async Task<ActionResult> ResetPasswordWithToken([FromBody] ResetPasswordRequest payload)
    {
        var result = await _mediator.Send(payload);
        return Ok(result);
    }
}
