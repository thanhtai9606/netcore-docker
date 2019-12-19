namespace acb_app.Models
{
    public class RegisterAccount
    {
        public string Username { set; get; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}