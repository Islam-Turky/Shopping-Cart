using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class ShoppingCart
    {
        [Key]
        public string ShoppingCartId { get; set; } = string.Empty!;

        [Required]
        public Product Product { get; set; } = null!;

        [Required]
        public IdentityUser? UserIdentityName { get; set; }
    }
}
