using DeveloperTestTask.Models;
using System.Net.Http.Json;

namespace DeveloperTestTask.Services;

public class AuthenticationService
{
    HttpClient httpClient = new HttpClient();

    public async Task<string> LoginAsync(string userName, string password)
    {
        var response = await httpClient.PostAsJsonAsync<LoginRequest>(@"https://localhost:7162/Login",
            new LoginRequest(userName, password));

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
