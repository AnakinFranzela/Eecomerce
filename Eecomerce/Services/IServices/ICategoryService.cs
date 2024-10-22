using Eecomerce.DTO;
using Eecomerce.Entities;
using Eecomerce.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eecomerce.Services.IServices
{
    public interface ICategoryService
    {
        public List<Category> GetCategoryList();
        bool AddCategory(Category category);
        Category? GetCategoryById(int? id);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        void SetModelStateDictionary(IValidationDictionary modelState);
        public SearchResult<Category> Search(Category category, string sortColumn, int start, int length);

    }
}
