namespace LaborSystem.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateOnly Lastlogin { get; set; }
        public DateOnly LockoutEndTime { get; set; }
    }
}