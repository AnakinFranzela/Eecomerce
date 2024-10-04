using Eecomerce.Entities;
using Eecomerce.Repositories.IRepositories;
using Eecomerce.Services.IServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eecomerce.Services
{
    public class CategoryService : ICategoryService
    {
        private ModelStateDictionary? _modelState;
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<Category> GetCategoryList()
        {
                return _repository.ToList();
        }

        public bool AddCategory(Category category)
        {
            return _repository.Add(category);
        }

        public Category? GetCategoryById(int? id)
        {
            return _repository.FindById(id);
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                return _repository.Update(category);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCategory(int id)
        {
            return _repository.Delete(id);
        }
    }
}
