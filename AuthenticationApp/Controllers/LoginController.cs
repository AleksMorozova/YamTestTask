using AuthenticationApp.Models;
using AuthenticationApp.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApp.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public LoginController(IAuthenticationService authenticationService, IMapper mapper) => 
        (_authenticationService, _mapper) = (authenticationService, mapper);

    [HttpPost(Name = "Login")]
    public async Task<ActionResult<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var user = await _authenticationService.LoginAsync(request);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(new LoginResponse(_mapper.Map<UserResponse>(user)));
    }
}
