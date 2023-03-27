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

        


        /*
         * Navigation to Payment Page, handles Payment Information 
         */
        RegisterForm regForm = new RegisterForm();
        [HttpPost]
        public IActionResult RegSuccess(RegisterForm formInfo)
        {
            if (formInfo == null)
            {
                return View("Registration");
            }
            else
            {
                Console.WriteLine("!!!!!!!!!"+formInfo.ParentName);
                regForm.ChildName = formInfo.ChildName;
                regForm.ChildAge = formInfo.ChildAge;
                regForm.Phone = formInfo.Phone;
                regForm.NumberOfChildren = formInfo.NumberOfChildren;  

                return View("Payment"); 
            } 

        }
        [HttpPost]
        public IActionResult PaymentProceed(Payment payInfo)
        {
            Console.WriteLine(">>>>>>>>"+payInfo.FullName);
            Console.WriteLine(">>>>>>>>" + payInfo.CardNumber);

            Payment pay = new Payment
            {
               FullName = payInfo.FullName,
               CardNumber = payInfo.CardNumber,
               ExpiryMonth = payInfo.ExpiryMonth,
               ExpiryYear = payInfo.ExpiryYear,
               CVVNumber = payInfo.CVVNumber,
               BFullName = payInfo.BFullName,
               BEmail = payInfo.BEmail,
               BAddress = payInfo.BAddress,
               BCity = payInfo.BCity,
               BPostalCode = payInfo.BPostalCode,
               ChildName = regForm.ChildName,
               ChildAge = regForm.ChildAge,
               Phone = regForm.Phone,
               NumberOfChildren = regForm.NumberOfChildren,

            };
            Console.WriteLine(">>>>>>>>!!!" + pay.ChildName);
            ViewBag.Message = pay;
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