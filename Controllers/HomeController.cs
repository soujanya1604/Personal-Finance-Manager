using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Models;

namespace Personal_Finance_Manager.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(new User());
    }

    [HttpPost]
    public IActionResult Login(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
        {
            TempData["LoginError"] = "Email and password are required.";
            return View(user);
        }

        var userInfo = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

        if (user == null)
        {
            TempData["LoginError"] = "Incorrect email or password.";
            return View(user);
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        return RedirectToAction("Dashboard", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
