namespace Capstone1.Models
{
    public class RegisterForm
    {
        public string Location { get; set; } = string.Empty;

        public string ParentName { get; set; } = string.Empty;

        public string ChildName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string ChildAge { get; set; } = string.Empty;

        public string ContactPreference { get; set; } = string.Empty;

        public bool? NewCustomer { get; set; } 
    }
}
