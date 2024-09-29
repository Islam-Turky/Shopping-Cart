using SampleApplication.ViewModels;

namespace SampleApplication.Models
{
    public interface IUserRepository
    {
        void Register(User user);
        User Login(string userName, string email, string password);
        List<User> GetAll();
        User GetByEmailAndPass(string email, string pass);
    }
}
