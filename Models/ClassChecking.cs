using Capstone1.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Diagnostics;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Drawing;
using System;
using Microsoft.IdentityModel.Tokens;

namespace Capstone1.Models
{
    public class ClassChecking
    {

        /*
         * Each method check the number of clients register for each class, and in the home controller call if it is greater than the maximum an alert notifies the user.\
         * 
         * the TotalAttendies counts the total number of rows, or clients within the table. 
         * 
         * 
         * TheCheckIfRegistered method used the entered email to see if it already exsist within the database.
         * 
         */


        public int TotalAttendies()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);

            int numRows; 

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows for Total Clients: {numRows}");
                conn.Close();

            }
            return numRows;
        }

        public Boolean TheCheckIfRegistered(string providedEmail)
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT Count(*) FROM ClientInformation WHERE Email = '"+providedEmail+"' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);

            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows for if registard: {numRows}");
                 if (numRows > 1)
                {
                    return true;
                }
                conn.Close();

            }


            return false;
        }

        public int GeogrgetownZeroToFourYears()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation WHERE Location = 'Geogrgetown, Children 0 to 4 Years' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);
            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows Goergetown 0-18 Years: {numRows}");
                conn.Close();

            }
            return numRows;
        }

        public int GeogrgetownZeroToEighteenMonths()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation WHERE Location = 'Geogrgetown, Children 0 to 18 Months' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);
            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows Goergetown 0-18 Months:: {numRows}");
                conn.Close();

            }
            return numRows;
        }
        public int OakvilleZeroToFourYears()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation WHERE Location = 'Oakville, Children 0 to 4 Years' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);
            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows Oakville 0-4 Years:: {numRows}");
                conn.Close();

            }
            return numRows;
        }

        public int OakvilleZeroToEighteenMonths()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation WHERE Location = 'Oakville, Children 0 to 18 Months' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);
            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows Oakville 0-18 Months: {numRows}");
                conn.Close();

            }
            return numRows;
        }

        public int MiltonZeroToFourYears()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation WHERE Location = 'Milton, Children 0 to 4 Years' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);
            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows Milton 0-4 Years:: {numRows}");

                conn.Close();
            }
            return numRows;
        }

        public int MiltonZeroToEighteenMonths()
        {
            SqlConnection conn = new SqlConnection(GetConString.ConString());
            String sql = "SELECT COUNT(*) FROM ClientInformation WHERE Location = 'Milton, Children 0 to 18 Months' ;";   //counting the number of rows
            SqlCommand cmd = new SqlCommand(sql, conn);
            int numRows;

            using (conn)
            {
                conn.Open();
                numRows = (int)cmd.ExecuteScalar();

                Console.WriteLine($"Number of rows Goergetown 0-18 Months:: {numRows}");

                conn.Close();
            }
            return numRows;
        }




    }
}
