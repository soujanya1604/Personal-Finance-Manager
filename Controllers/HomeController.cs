using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Models;

namespace Personal_Finance_Manager.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    private readonly ILogger<HomeController> _logger;

    private readonly StockController _stockController;

    public HomeController(ILogger<HomeController> logger, AppDbContext context,StockController stockController)
    {
        _logger = logger;
        _context = context;
        _stockController = stockController;
    }

    public async Task<IActionResult> Index()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");

        if (!userId.HasValue)
        {
            // If user is not logged in, show the welcome page with login link
            ViewBag.IsLoggedIn = false;
            return View(); // Render the home page with the message and sign-in option
        }

        // If user is logged in, fetch the transactions and stock data
        var transactions = _context.Transactions.Where(t => t.UserId == userId).ToList();
        ViewBag.IsLoggedIn = true;

        // Fetch stock data by calling the Quote method of StockController
        await _stockController.Quote("AAPL");

        // Now the stock data should be available in ViewBag.roller methods,
        return View(transactions); // Render the user's dashboard page
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
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserId");  
        return RedirectToAction("Login", "Home");  
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
