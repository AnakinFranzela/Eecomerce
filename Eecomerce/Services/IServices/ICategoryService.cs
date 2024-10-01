using Eecomerce.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eecomerce.Services.IServices
{
    public interface ICategoryService
    {
        public List<Category> GetCategoryList();
        bool AddCategory(Category category);

	}
}
