using ClothesStore.API.Common;
using ClothesStrore.Application.User.ChangePassword;
using ClothesStrore.Application.User.CreaeteUser;
using ClothesStrore.Application.User.ForgotPassword;
using ClothesStrore.Application.User.GetAllUsers;
using ClothesStrore.Application.User.LoginUser;
using ClothesStrore.Application.User.RefreshToken;
using ClothesStrore.Application.User.ResetPasswordWithToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Tnef;

namespace ClothesStore.API.Controllers;

[Route("api/identity")]
[ApiController]
public class IdentityController : ApiControllerBase
{
    [HttpPost("register-user")]
    [AllowAnonymous]
    public async Task<ActionResult> Register([FromBody] CreateUserRequest payload)
    {
        var userCreated = await Mediator.Send(payload);
        if (userCreated != null)
            return Ok(userCreated);
        else
            return BadRequest();
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("get-all-users")]
    public async Task<ActionResult> GetAllUsers()
    {
        var response = await Mediator.Send(new GetAllUsersRequest(), HttpContext.RequestAborted);
        return Ok(response);
    }
    [HttpPost("login-user")]
    [AllowAnonymous]
    public async Task<ActionResult> Login([FromBody] LoginUserRequest paylaod)
    {
        var response = await Mediator.Send(paylaod);
        return Ok(response);
    }
    [HttpPost("change-password")]
    [AllowAnonymous]
    public async Task<ActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequest model)
    {
        var command = new ChangePasswordRequest
        {
            Id = id,
            CurrentPassword = model.CurrentPassword,
            NewPassword = model.NewPassword,
            RepeatPassword = model.RepeatPassword
        };
        var result = await Mediator.Send(command);
        var jsonObject = Deserialize.JsonDeserialize(result);
        jsonObject.TryGetValue("Message", out string messageValue);

        if (bool.Parse(messageValue))
            return Ok(jsonObject);
        else
            return BadRequest(jsonObject);
    }
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<ActionResult> ForgotPassword([FromBody] EmailSendRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<ActionResult> ResetPasswordWithToken([FromBody] ResetPasswordRequest payload)
    {
        var result = await Mediator.Send(payload);
        return Ok(result);
    }
    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenCommand payload)
    {
        var result = await Mediator.Send(payload);
        return Ok(result);
    }   
}
