using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace Capstone1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        AllInformation allInfo = new AllInformation();

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



        /*
         * Navigation to Payment Page, handles Payment Information 
         */
       
        [HttpPost]
        public IActionResult RegSuccess(RegisterForm formInfo)
        {
            if (formInfo == null)
            {
                return View("Registration");
            }
            else
            {
                allInfo.ChildName = formInfo.ChildName;
                allInfo.ChildAge = formInfo.ChildAge;
                allInfo.Phone = formInfo.Phone;
                allInfo.NumberOfChildren = formInfo.NumberOfChildren;
                

                return View("Payment"); 
            } 

        }
        [HttpPost]
        public IActionResult PaymentProceed(Payment payInfo)
        {
            allInfo.FullName = payInfo.FullName;
            allInfo.CardNumber = payInfo.CardNumber;
            allInfo.ExpiryMonth = payInfo.ExpiryMonth;
            allInfo.ExpiryYear = payInfo.ExpiryYear;
            allInfo.CVVNumber = payInfo.CVVNumber;
            allInfo.BFullName = payInfo.BFullName;
            allInfo.BEmail = payInfo.BEmail;
            allInfo.BAddress = payInfo.BAddress;
            allInfo.BCity = payInfo.BCity;
            allInfo.BPostalCode = payInfo.BPostalCode;


            Console.WriteLine("LOOK HERE: " + allInfo.ChildName);

            ViewBag.Message = allInfo;
            return View("Complete");
        }



        //temporary 
        public IActionResult temp()
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