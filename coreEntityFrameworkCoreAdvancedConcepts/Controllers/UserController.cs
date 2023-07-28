using coreEntityFrameworkCoreAdvancedConcepts.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreEntityFrameworkCoreAdvancedConcepts.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDBContext _context;
        public UserController() 
        {
            _context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
