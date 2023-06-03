namespace eUseControl.Web.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        public string Privilege { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}