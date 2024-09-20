using DeveloperTestTask.Services;


Console.WriteLine("Enter username:");
string userName = Console.ReadLine();

Console.WriteLine("Enter password:");
string password = Console.ReadLine();

var authenticationService = new AuthenticationService();
var notificationService = new NotificationService();

// TODO: hash password
var loginResult = await authenticationService.LoginAsync(userName, password);

await notificationService.SendNotificationAsync(loginResult);

Console.ReadKey();