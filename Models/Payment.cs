namespace Capstone1.Models
{
    public class Payment
    {
        public string FullName { get; set; } = string.Empty;

        public string CardNumber { get; set; } = string.Empty;

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public int CVVNumber { get; set; }

        public string BFullName { get; set; } = string.Empty;

        public string BEmail { get; set; } = string.Empty;

        public string BAddress { get; set; } = string.Empty;

        public string BCity { get; set; } = string.Empty;
        public string BPostalCode { get; set; } = string.Empty;
    }
}
