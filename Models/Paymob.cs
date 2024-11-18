using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class Paymob
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Order { get; set; } = string.Empty;
    }
}
