namespace SampleApplication.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public UserRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public void Add(User user) 
        {
            _storeDbContext.users.Add(user);
        }

        public List<User>? GetAll() 
        {
            return _storeDbContext.users.ToList();
        }

        public User? Get(string id) 
        {
            return _storeDbContext.users.FirstOrDefault(e => e.UserId == id);
        }
    }
}
