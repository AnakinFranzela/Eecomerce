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

        public List<Category> ToList()
        {
            return _context.Categories.ToList();
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
    }
}
