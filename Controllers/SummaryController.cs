using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Models;

namespace Personal_Finance_Manager.Controllers
{
    public class SummaryController : Controller
    {
        private readonly AppDbContext _context;
        public SummaryController(AppDbContext context) => _context = context;

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var income = _context.Transactions.Where(t => t.UserId == userId && t.Type == "Income").Sum(t => t.Amount);
            var expenses = _context.Transactions.Where(t => t.UserId == userId && t.Type == "Expense").Sum(t => t.Amount);
            var net = income - expenses;

            var summary = new Summary { TotalIncome = income, Expenses = expenses, NetBalance = net };
            return View(summary);
        }

    }
}
