namespace SampleApplication.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User>? GetAll();
        User? Get(string id);
    }
}
