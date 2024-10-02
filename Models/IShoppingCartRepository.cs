using Microsoft.AspNetCore.Identity;

namespace SampleApplication.Models
{
    public interface IShoppingCartRepository
    {
        public void Add(ShoppingCart shoppingCart);
        public IQueryable<ShoppingCart> GetAllForUser(ShoppingCart cart);
    }
}
