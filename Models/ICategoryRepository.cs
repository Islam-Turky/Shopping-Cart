namespace SampleApplication.Models
{
    public interface ICategoryRepository : ICommonMethodRepository
    {
        void Add(Category category);
        List<Category>? GetAll();
        Category? GetById(string cid);
    }
}
