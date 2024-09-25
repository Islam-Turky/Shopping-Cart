namespace SampleApplication.Models
{
    public interface IShoppingCartRepository
    {
        public void Add(ShoppingCart shoppingCart);
        public List<ShoppingCart>? GetAll(User user);
    }
}
