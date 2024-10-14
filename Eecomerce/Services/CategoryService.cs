using Eecomerce.Entities;
using Eecomerce.Helpers;
using Eecomerce.Repositories.IRepositories;
using Eecomerce.Services.IServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace Eecomerce.Services
{
    public class CategoryService : ICategoryService
    {
        private IValidationDictionary? _modelState;
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public void SetModelStateDictionary(IValidationDictionary modelState)
        {
            _modelState = modelState;
        }

        public bool ValidateCategory(Category category)
        {
            if(_modelState == null)
            {
                throw new ArgumentNullException(nameof(_modelState));
            }

            if(category.Name.ToLower() == "test")
            {
                _modelState.AddError("Name", "\"Test\" is an invalid value!");
            }

            Category category1 = _repository.CheckForExistingCategory(category.Name);
            if (category1 != null)
            {
                _modelState.AddError("", $"Category {category1.Name} already exists.");
            }

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(category.Name);
            if (match.Success)
            {
                _modelState.AddError("", "Category name can not have a number.");
            }

			return _modelState.IsValid;
        }

        public List<Category> GetCategoryList()
        {
            return _repository.ToList();
        }

        public bool AddCategory(Category category)
        {
            try
            {
                if(!ValidateCategory(category))
                {
                    return false;
                }
                return _repository.Add(category);
            }
            catch
            {
                return false;
            }
        }

        public Category? GetCategoryById(int? id)
        {
            return _repository.FindById(id);
        }

        public bool UpdateCategory(Category category)
        {
			try
			{
				if (!ValidateCategory(category))
				{
					return false;
				}
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
