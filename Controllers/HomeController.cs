using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Diagnostics;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Drawing;
using System;
using System.Data;
using Google.Protobuf.WellKnownTypes;

namespace Capstone1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
 
        private readonly AllInformation _context;

        AllInformation allInfo = new AllInformation();

        public HomeController(AllInformation context , ILogger<HomeController> logger)
        {
            _context = context;
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


                AllInformation umodel = new AllInformation();
                umodel.ParentName = formInfo.ParentName;
                umodel.ChildName = formInfo.ChildName;
                umodel.ChildAge = formInfo.ChildAge;
                umodel.NumberOfChildren = formInfo.NumberOfChildren;
                umodel.Email = formInfo.Email;
                umodel.Phone = formInfo.Phone;

                int result = umodel.SaveDetails();
                if (result > 0)
                {
                    Console.WriteLine("Data Saved Successfully");
                }

                return View("Payment"); 
            } 

        }

        public AllInformation GetAllInfo()
        {
            return allInfo;
        }

        [HttpPost]
        public IActionResult PaymentProceed(Payment allInfo)
        {
            Console.WriteLine(allInfo.BEmail);

            AllInformation umodel = new AllInformation();

            if (allInfo.CVCNumber != 0 && allInfo.CardNumber != null)
            {
                umodel.Haspaid = "Complete";
                int result = umodel.PaidConfirmation(allInfo.BEmail);
                if (result > 0)
                {
                    Console.WriteLine("Data Saved Successfully #2");
                }
                else
                {
                    Console.WriteLine(allInfo.BEmail);
                    Console.WriteLine(umodel.Email);
                    Console.WriteLine("Data Not Saved Successfully");
                    umodel.Haspaid = "Not-Paid";
                }
            }


            //ViewBag.Message = allInfo;
            //return View("Complete");
            return View();
        }



        //temporary 
        public IActionResult temp()
        {
            return View("Payment");
        }

        public IActionResult stripe()
        {
            return View("StripePayment");
        }

        //Admin view for Jenny's class list
        public IActionResult ClassList()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String connectionString = GetConString.ConString();
            String sql = "SELECT * FROM ClientInformation";
            SqlCommand cmd = new SqlCommand(sql, conn);

            var model = new List<AllInformation>();
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var info = new AllInformation();
                    info.ParentName = rdr["ParentName"].ToString();
                    info.ChildName = rdr["ChildName"].ToString();

                    Object numChild = rdr["NumOfChildren"];
                    info.NumberOfChildren = numChild.ToString();

                    info.ChildAge = rdr["ChildAge"].ToString();


                    info.Email = rdr["Email"].ToString();
                    info.Phone = rdr["PhoneNumber"].ToString();
                    info.Haspaid = rdr["PaymentStatus"].ToString();
                    model.Add(info);
                }

            }
            return View(model);
            //return View("ClassList");
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