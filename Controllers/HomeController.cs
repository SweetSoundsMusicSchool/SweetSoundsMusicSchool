using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Capstone1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GotoReg()
        {
            return View("Registration");
        }

        public IActionResult ClassDetails()
        {
            return View("ClassDetails");
        }

        [HttpPost]

        public IActionResult GotoReg(RegisterForm rf)
        {
            return View("Registration");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}