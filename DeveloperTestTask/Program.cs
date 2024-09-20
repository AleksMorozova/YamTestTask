using DeveloperTestTask.Services;


Console.WriteLine("Enter username:");
string userName = Console.ReadLine();

Console.WriteLine("Enter password:");
string password = Console.ReadLine();

var serv = new AuthenticationService();


Console.WriteLine(await serv.LoginAsync(userName, password));

Console.ReadKey();