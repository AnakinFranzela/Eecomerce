using Eecomerce.Data;
using Eecomerce.Entities;
using Eecomerce.Repositories.IRepositories;
using Eecomerce.DTO;

namespace Eecomerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private int RowCount { get; set; }

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

        public SearchResult<Category> GetPageData(Category category, string sortColumn, int start, int length)
        {
            IQueryable<Category> query = _context.Set<Category>();
            query = Search(category, query);
            query = OrderBy(sortColumn, query);
            query = WithPagination(start, length, query);

            SearchResult<Category> result = new SearchResult<Category>();
            result.RowCount = RowCount;
            result.Data = query.ToList();
            return result;
        }

        private IQueryable<Category> OrderBy(string value, IQueryable<Category> query)
        {
            switch(value)
            {
                case "-name":
                    return query.OrderByDescending(x => x.Name);
                case "-displayOrder":
                    return query.OrderByDescending(x => x.DisplayOrder);
                case "displayOrder":
                    return query.OrderBy(x => x.DisplayOrder);
                default:
                    return query.OrderBy(x => x.Name);
            }
        }

        private IQueryable<Category> WithPagination(int start, int length, IQueryable<Category> query)
        {
            RowCount = query.Count();
            return query.Skip(start).Take(length);
        }

        private IQueryable<Category> Search(Category category, IQueryable<Category> query)
        {
            if (!String.IsNullOrEmpty(category.Name))
            {
                query = query.Where(x => x.Name!.ToUpper().Contains(category.Name.ToUpper()));
            }
            if(category.DisplayOrder != 0)
            {
                query = query.Where(x => x.DisplayOrder == category.DisplayOrder);
            }
            return query;
        }
    }
}
