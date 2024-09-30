using Eecomerce.Entities;
using Eecomerce.Repositories.IRepositories;

namespace Eecomerce.Repositories
{
	public class CategoryRepositoryTest : ICategoryRepository
	{
		public bool Add(Category category)
		{
			return false;
		}

		public List<Category> ToList()
		{
			List<Category> list = new List<Category>();
			list.Add(new Category
			{
				Name = "Ninja",
				DisplayOrder = 16
			});
			
			return list;
		}
	}
}
