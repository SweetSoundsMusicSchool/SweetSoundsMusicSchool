using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin model)
        {
            if (model.Username == "admin" && model.Password == "admin123")
            {
                
                return View("ClassList");
            }

            
           // ModelState.AddModelError("", "Invalid username or password");
            return View("AdminLogIn" , model);
        }
    }
}
