namespace Capstone1.Models
{
    public class AllInformation
    {
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
    }
}
