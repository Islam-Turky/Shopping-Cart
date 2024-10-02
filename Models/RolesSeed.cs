using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SampleApplication.Models
{
    public class RolesSeed
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            StoreDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<StoreDbContext>();

            string[] roles = new string[] { "Admin", "Customer", "Trader" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                if (!context.Roles.Any(e => e.Name == role)) 
                {
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }
            context.SaveChanges();
        }
    }
}
