namespace SampleApplication.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public ShoppingCartRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public void Add(ShoppingCart cart) 
        {
            _storeDbContext.shoppingCarts.Add(cart);
        }

        public List<ShoppingCart>? GetAll(User u) 
        {
            return _storeDbContext.shoppingCarts.Where(e => e.User == u).ToList();
        }
    }
}
