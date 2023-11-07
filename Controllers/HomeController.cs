using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Diagnostics;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Drawing;
using System;
using Microsoft.IdentityModel.Tokens;

namespace Capstone1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
 
        private readonly AllInformation _context;

        AllInformation allInfo = new AllInformation();

         string ClassType;
         string Location;

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
       
        public IActionResult ClassPicker()
        {
            var model = new ClassChoosenDetails();
            return View(model);

            //return View("ClassPicker");
        }

        /*
         * Navigation to the registration page with form.
         */
        [HttpGet]
        public IActionResult Registration(string Lesson)
        {
         
           Console.WriteLine("Class Pick, Submitted Info:"+ Lesson);

            ClassChecking check = new ClassChecking();

            // if all classes are complety full
            if (check.TotalAttendies() >= 24)
            {
                TempData["AlertMessage"] = "Unfortunately all the classes are full. Please contact for next avalible sessions";

                return RedirectToAction("Index");

            }
            // method calls to do the 6 checks for each class and if its full or not.
            //#1
            else if (check.GeogrgetownZeroToFourYears() >= 2)
            {
                TempData["AlertMessage"] = "Unfortunately Geogretown ages 0 to 4 years is full. Please contact for next avalible session, or select a diffrent class. ";
                return RedirectToAction("ClassPicker");
            }
            //#2
            else if (check.GeogrgetownZeroToEighteenMonths() >= 8)
            {
                TempData["AlertMessage"] = "Unfortunately Geogretown ages 0 to 18 Months is full. Please contact for next avalible session, or select a diffrent class";
                return RedirectToAction("ClassPicker");
            }
            //#3
            else if (check.OakvilleZeroToFourYears() >= 8)
            {
                TempData["AlertMessage"] = "Unfortunately Oakvill ages 0 to 4 Years is full. Please contact for next avalible session, or select a diffrent class";
                return RedirectToAction("ClassPicker");
            }
            //#4
            else if (check.OakvilleZeroToEighteenMonths() >= 8)
            {
                TempData["AlertMessage"] = "Unfortunately Oakville ages 0 to 18 Months is full. Please contact for next avalible session, or select a diffrent class";
                return RedirectToAction("ClassPicker");
            }
            //#5
            else if (check.MiltonZeroToFourYears() >= 8)
            {
                TempData["AlertMessage"] = "Unfortunately Milton ages 0 to 4 years is full. Please contact for next avalible session, or select a diffrent class";
                return RedirectToAction("ClassPicker");
            }
            //#6
            else if (check.MiltonZeroToEighteenMonths() >= 8)
            {
                TempData["AlertMessage"] = "Unfortunately Milton ages 0 to 4 Years is full. Please contact for next avalible session, or select a diffrent class";
                return RedirectToAction("ClassPicker");
            }
            else
            {
                RegisterForm model = new RegisterForm();
                model.Location = Lesson;
                Location = Lesson;
                return View("Registration", model);
            }

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
            ClassChecking check = new ClassChecking();

            AllInformation umodel = new AllInformation();
                umodel.ParentName = formInfo.ParentName;
                umodel.ChildName = formInfo.ChildName;
                umodel.ChildAge = formInfo.ChildAge;
                umodel.NumberOfChildren = formInfo.NumberOfChildren;
                umodel.Email = formInfo.Email;
                umodel.Phone = formInfo.Phone;
                //umodel.ClassType = formInfo.LessonType;
                umodel.Location = formInfo.Location;

                Console.WriteLine("->" + Location);

                if (formInfo.Location.IsNullOrEmpty())
                {
                    Console.WriteLine("Its Empty !!");
                }

                Console.WriteLine("Class Pick, Submitted Info #2:" + formInfo.Location);

                if(check.TheCheckIfRegistered(formInfo.Email) == true)
                {
                    //true if eamil exisits in the database
                    //alert and prompt to try again
                    TempData["AlertMessage"] = "Looks Like a client with this email: " +formInfo.Email+ " Has  registered before, Please try again. ";
                    //return register page to try again
                    RegisterForm model = new RegisterForm();
                    model.Location = formInfo.Location;
                    return View("Registration", model);
                }
                else
                {
                    //else, false, save the data
                    int result = umodel.SaveDetails();
                    if (result > 0)
                    {
                        Console.WriteLine("Data Saved Successfully");
                    }
                }

              

            return View("Payment");

        }

        public AllInformation GetAllInfo()
        {
            return allInfo;
        }

        [HttpPost]
        public IActionResult PaymentProceed(Payment allInfo)
        {

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
                    Console.WriteLine("Data Not Saved Successfully");
                    umodel.Haspaid = "Not-Paid";
                }
            }

            //database query to get the latest entry to show the users entered information
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT TOP 1 * FROM ClientInformation ORDER BY ClientID DESC";
            SqlCommand cmd = new SqlCommand(sql, conn);

            var results = new List<AllInformation>();
            using (conn)
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var info = new AllInformation();
                    info.ParentName = rdr["ParentName"].ToString();
                    info.ChildName = rdr["ChildName"].ToString();

                    object numChild = rdr["NumOfChildren"];
                    info.NumberOfChildren = numChild.ToString();

                    info.ChildAge = rdr["ChildAge"].ToString();


                    info.Email = rdr["Email"].ToString();
                    info.Phone = rdr["PhoneNumber"].ToString();

                    info.ClassType = rdr["ClassType"].ToString();
                    info.Location = rdr["Location"].ToString();

                    info.Haspaid = rdr["PaymentStatus"].ToString();
                    results.Add(info);

                }
                //conn.Close();

            }
            //return View("Complete");
            return View("Complete" ,results);
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

        

        //login controller method
        public IActionResult AdminLogIn()
        {
            return View("AdminLogin");
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