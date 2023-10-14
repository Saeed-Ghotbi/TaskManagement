namespace TaskManagement.DTOs.User
{
    public class CreateUserDto
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }

    }
}
