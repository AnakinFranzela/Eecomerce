using Eecomerce.Data;
using Eecomerce.Entities;
using Eecomerce.Repositories.IRepositories;

namespace Eecomerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                int stateNumber = _context.SaveChanges();
                return stateNumber > 0;
            }
            catch
            {
                return false;
            }
        }

		public bool Update(Category category)
		{
			try
			{
				_context.Categories.Update(category);
				int stateNumber = _context.SaveChanges();
				return stateNumber > 0;
			}
			catch
			{
				return false;
			}
		}

		public List<Category> ToList()
        {
            return _context.Categories.ToList();
        }

        public Category? CheckForExistingCategory(string? categoryName)
        {
            List<Category> categories = _context.Categories.ToList();
            if (String.IsNullOrEmpty(categoryName))
            {
                return null;
            }

            return _context.Categories.Where(s => s.Name!.ToUpper().Equals(categoryName.ToUpper())).FirstOrDefault();

		}

        public Category? FindById(int? id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            Category? category = _context.Categories.Find(id);
            return category;
        }

        public bool Delete(int id)
        {
            Category? category = FindById(id);
            if (category == null)
            {
                return false;
            }

            try
            {
                _context.Categories.Remove(category);
                int stateNumber = _context.SaveChanges();
                return stateNumber > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
