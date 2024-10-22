using Eecomerce.DTO;
using Eecomerce.Entities;

namespace Eecomerce.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        bool Add(Category entity);
        List<Category> ToList();
        Category? FindById(int? id);
        bool Update(Category category);
        bool Delete(int id);
        Category? CheckForExistingCategory(string? categoryName);
        SearchResult<Category> GetPageData(Category category, string sortColumn, int start, int length);

    }
}
