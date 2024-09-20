using AuthenticationApp.DataAccess.Model;
using AuthenticationApp.DataAccess.Repositories;
using AuthenticationApp.Models;

namespace AuthenticationApp.Services;

public interface IAuthenticationService
{
    public Task<User?> LoginAsync(LoginRequest loginRequest);
}

public class AuthenticationService  : IAuthenticationService
{
    private IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository) => _userRepository = userRepository;

    public Task<User?> LoginAsync(LoginRequest loginRequest) =>
        _userRepository.GetUser(loginRequest.UserName, loginRequest.Password);
}
