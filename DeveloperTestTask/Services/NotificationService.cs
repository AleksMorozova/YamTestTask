using DeveloperTestTask.Models;

namespace DeveloperTestTask.Services;

public class NotificationService
{
    HttpClient httpClient = new HttpClient();

    public async Task SendNotificationAsync(LoginResponse loginResponse)
    {
        var response = await httpClient.PostAsync(@"https://localhost:7067/Notification", new StringContent(loginResponse.Status));

        response.EnsureSuccessStatusCode();
    }
}
