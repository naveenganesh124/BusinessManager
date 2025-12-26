namespace BusinessManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!; // plain for now (we’ll hash later)
        public string Role { get; set; } = "User";
        public bool IsActive { get; set; } = true;
    }
}
