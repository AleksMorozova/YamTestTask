using Microsoft.AspNetCore.Mvc;
using NotificationApp.Models;
using NotificationApp.Services;

namespace NotificationApp.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private INotificationService _notificatioService;

    public NotificationController(INotificationService notificatioService) =>
        _notificatioService = notificatioService;

    [HttpPost(Name = "Login")]
    public ActionResult LoginAsync(NotificationRequest request)
    {
        return Ok();
    }
}
