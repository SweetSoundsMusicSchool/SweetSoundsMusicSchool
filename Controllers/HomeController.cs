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

        /*
         * Navigation to the ClassPicker Page, Two drop downs to select class details.
         */
        public IActionResult ClassPicker(ClassChoosenDetails classDetails)
        {
            return View("ClassPicker");
        }

        /*
         * Navigation to the registration page with form.
         */
        public IActionResult Registration()
        {
            return View("Registration");

        }

        /*
         * Navigation to Class Detail, contains content
         */
        public IActionResult ClassDetails()
        {
            return View("ClassDetails");
        }

        /*
         * Navigation to price Info, contains content
         */
        public IActionResult PriceInfo()
        {
            return View("PriceInfo");
        }

        /*
         * Navigation to About Page, contains content
         */
        public IActionResult about()
        {
            return View("about");
        }

        [HttpPost]


        /*
         * Navigation to Payment Page, handles Payment Information 
         */
        public IActionResult RegSuccess(RegisterForm formInfo)
        {
            if (formInfo == null)
            {
                return View("Registration");
            }
            else
            {
                return View("Payment");
            } 

        }
        [HttpPost]
        public IActionResult PaymentProceed(Payment payInfo)
        {
            Console.WriteLine(">>>>>>>>."+payInfo.FullName);
            
            return View("Payment");
        }



        //temporary 
        public IActionResult temp(Payment payInfo)
        {
            return View("Payment");
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