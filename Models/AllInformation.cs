using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using System.Data.SqlClient;

namespace Capstone1.Models
{
    public class AllInformation: DbContext
    {
        public AllInformation()
        {
        }


        public AllInformation(DbContextOptions<DbContext> options)
         : base(options)
        {
        }

        public string ParentName { get; set; } = string.Empty;
        public string ChildName { get; set; } = string.Empty;
        public string ChildAge { get; set; } = string.Empty;
        public string NumberOfChildren { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        /*Payment Information*/
        public string FullName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public int ExpiryMonth { get; set; } = 0;

        public int ExpiryYear { get; set; } = 0;

        public int CVVNumber { get; set; } = 0;

        public string BFullName { get; set; } = string.Empty;

        public string BEmail { get; set; } = string.Empty;

        public string BAddress { get; set; } = string.Empty;

        public string BCity { get; set; } = string.Empty;
        public string BPostalCode { get; set; } = string.Empty;

        public string Haspaid { get; set; }



        public int SaveDetails(string Lessontype, string Location)
        {
            Console.WriteLine("Information:" + Lessontype + " " + Location);

            SqlConnection con = new SqlConnection(GetConString.ConString());

            string query = "INSERT INTO ClientInformation(ParentName,ChildName,NumOfChildren,ChildAge,Email,PhoneNumber,ClassType,Location) " +
                "values ('" + ParentName + "','" + ChildName + "','" + NumberOfChildren + "','" 
                 + ChildAge + "','"+Email +"','"+Phone+"','"+ Lessontype+"','"+ Location +"')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int PaidConfirmation(string email)
        {
            SqlConnection con = new SqlConnection(GetConString.ConString());
            string query = "INSERT INTO ClientInformation (PaymentStatus) VALUES ('" + Haspaid + "') WHERE Email = '"+email+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
                return i;
        }
    }
}
