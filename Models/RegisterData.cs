using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Project.Models
{
    public class RegisterData
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string PanNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
