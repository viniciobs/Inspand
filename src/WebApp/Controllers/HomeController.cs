using Domain.Interfaces.Services;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Helpers;
using WebApp.Models;
using UserEntity = Domain.Entities.User;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IService<UserEntity> _service;
    private readonly IEmailService _emailService;

    public HomeController(
        ILogger<HomeController> logger,
        IService<UserEntity> service,
        IEmailService emailService) => 
        (_logger, _service, _emailService) = (logger, service, emailService);

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Requesting users...");

        var result =  await _service.GetAllAsync();
        var users = result.Select(x => UserDetail.MapFrom(x));

        return View(users);
    }

    public async Task New([FromBody] UserNew user)
    {
        _logger.LogInformation("Creating user...");

        var result = await _service.InsertAsync(new()
        {
            Age = user.Age,
            Email = user.Email,
            LastName = user.LastName,
            Name = user.Name,
            Password = user.Password.ToBase64()
        });

        if (result.IsValid is false) 
        {
            _logger.LogInformation(string.Join(';', result.Errors.Select(x => x.ErrorMessage)));
            return;
        }

        _emailService.SendEmail(
            to: user.Email,
            message: $"Olá, {user.Name}. Seja muito bem-vindo(a)!");
    }

    public IActionResult Privacy()
        => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}