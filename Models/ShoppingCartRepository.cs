namespace SampleApplication.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public ShoppingCartRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public void Create(ShoppingCart cart) 
        {
            _storeDbContext.shoppingCarts.Add(cart);
        }

        public void Edit(ShoppingCart cart) { }

        public ShoppingCart GetOne(string id) { return null; }
        public IEnumerable<ShoppingCart> GetAll()
        {  return _storeDbContext.shoppingCarts; }
        public void Edit(string id, ShoppingCart cart) { }
        public void Delete(string id) { }

        public int Save() { return _storeDbContext.SaveChanges(); }
        public IQueryable<ShoppingCart> GetAllForUser(ShoppingCart cart) 
        {
            return _storeDbContext.shoppingCarts.Where(e => e.UserIdentityName == cart.UserIdentityName);
        }
    }
}
