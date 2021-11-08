namespace WebApp.Models
{
    public class OTPViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OneTimePasswordFromUser { get; set; }
        public string OneTimePasswordGenerated { get; set; }
    }
}