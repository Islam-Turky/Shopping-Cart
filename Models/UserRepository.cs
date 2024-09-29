using SampleApplication.ViewModels;

namespace SampleApplication.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public UserRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public void Register(User user) 
        {
            _storeDbContext.users.Add(user);
        }

        public List<User> GetAll() 
        {
            return _storeDbContext.users.ToList();
        }

        public User Login(string userName ,string email, string password) 
        {
            User? loginUser = _storeDbContext.users.FirstOrDefault(e => e.UserName == userName && e.UserEmail == email && e.Password == password);
            return loginUser is null ? new User() { UserId = "", UserName = "NotFound", UserEmail = "", Password = "" } : loginUser;
        }

        public User GetByEmailAndPass(string email, string password) 
        {
            User? user = _storeDbContext.users.FirstOrDefault(e => e.UserEmail == email && e.Password == password);
            return user is null ? new User { } : user;
        }
    }
}
