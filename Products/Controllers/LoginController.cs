using Microsoft.AspNetCore.Mvc;
using Products.Service.ViewModels;

namespace Products.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromBody] LoginViewModel loginView)
        {
            RedirectToAction("Index", "Product");
            return View();
        }
    }
}
