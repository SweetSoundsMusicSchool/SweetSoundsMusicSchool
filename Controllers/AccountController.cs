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
using Microsoft.IdentityModel.Tokens;


namespace Capstone1.Controllers
{
    public class AccountController : Controller
    {

        private readonly AllInformation _context;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClassList(Admin model)
        {
            if (model.Username == "admin" && model.Password == "admin123")
            {

                SqlConnection conn = new SqlConnection(GetConString.ConString());
                String connectionString = GetConString.ConString();
                String sql = "SELECT * FROM ClientInformation";
                SqlCommand cmd = new SqlCommand(sql, conn);

                var infoModel = new List<AllInformation>();
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

                        info.ClassType = rdr["ClassType"].ToString();
                        info.Location = rdr["Location"].ToString();

                        info.Haspaid = rdr["PaymentStatus"].ToString();
                        infoModel.Add(info);
                    }

                }
                return View("../Home/ClassList", infoModel);

                //return View("ClassList");
            }

            
           // ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
    }
}
