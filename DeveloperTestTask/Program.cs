using DeveloperTestTask.Services;
using System.Threading.Tasks;


Console.WriteLine("Enter username:");
string userName = Console.ReadLine();

Console.WriteLine("Enter password:");
string password = Console.ReadLine();

var authenticationService = new AuthenticationService();
var notificationService = new NotificationService();

try
{
    // TODO: hash password
    var loginResult = await authenticationService.LoginAsync(userName, password);
    await notificationService.SendNotificationAsync(loginResult);
}
catch (Exception ex)
{
    Console.WriteLine($"Exception: {ex.Message}");
}

Console.ReadKey();