using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Finance_Manager.Models;

public class TransactionController : Controller
{
    private readonly AppDbContext _context;
    public TransactionController(AppDbContext context) => _context = context;

    public IActionResult Index()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var transactions = _context.Transactions.Where(t => t.UserId == userId).ToList();
        return View(transactions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Transaction tx)
    {
        tx.UserId = HttpContext.Session.GetInt32("UserId") ?? 0;
        tx.Date = DateTime.Now;
        _context.Transactions.Add(tx);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        return View(_context.Transactions.Find(id));
    }

    [HttpPost]
    public IActionResult Edit(Transaction tx)
    {
        _context.Transactions.Update(tx);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        return View(_context.Transactions.Find(id));
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var tx = _context.Transactions.Find(id);
        _context.Transactions.Remove(tx);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        return View(_context.Transactions.Find(id));
    }
}

