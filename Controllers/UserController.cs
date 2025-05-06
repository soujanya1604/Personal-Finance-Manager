using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Models;

namespace Personal_Finance_Manager.Controllers
{
    public class UserController : Controller
    {

        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int id)
        {
            var user = _context.Users.Find(id);
            return user == null ? NotFound() : View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            return user == null ? NotFound() : View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _context.Users.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

