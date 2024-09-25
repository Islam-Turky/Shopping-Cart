using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class User
    {

        [Key]
        public string UserId { get; set; } = string.Empty!;

        [Required]
        public string UserName { get; set; } = string.Empty!;

        [Required]
        public string UserEmail { get; set; } = string.Empty!;

        [Required]
        public string Password { get; set; } = string.Empty!;
    }
}
