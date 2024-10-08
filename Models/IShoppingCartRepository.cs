using Microsoft.AspNetCore.Identity;

namespace SampleApplication.Models
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public IQueryable<ShoppingCart> GetAllForUser(ShoppingCart cart);
    }
}
