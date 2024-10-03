using Eecomerce.Entities;

namespace Eecomerce.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        bool Add(Category entity);
        List<Category> ToList();
        Category? FindById(int? id);
        bool Update(Category category);



    }
}
