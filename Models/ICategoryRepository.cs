namespace SampleApplication.Models
{
    public interface ICategoryRepository : ICommonMethodRepository
    {
        void Add(Category category);
        IEnumerable<Category>? GetAll();
        Category? GetById(string cid);
    }
}
