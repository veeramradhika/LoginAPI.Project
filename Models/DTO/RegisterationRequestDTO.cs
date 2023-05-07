namespace LoginAPI.Project.Models.DTO
{
    public class RegisterationRequestDTO
    {
       
        public string? Email { get; set; }
        public string? PanNumber { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
