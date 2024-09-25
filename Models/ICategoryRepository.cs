namespace SampleApplication.Models
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        List<Category>? GetAll();
        Category? GetById(string cid);
    }
}
