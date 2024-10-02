using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eecomerce.ViewModels.Category
{
	public class CategoryViewModel
	{
		public int? Id { get; set; }
		[Required]
		[DisplayName("Category Name")]
		public string Name { get; set; }
		[Required]
		[DisplayName("Category Order")]
		public int DisplayOrder { get; set; }

		public void PopulateCategory(Eecomerce.Entities.Category category)
		{
			if(Id != null && Id != 0)
			{
				category.Id = (int)Id;
			}
			category.Name = Name;
			category.DisplayOrder = DisplayOrder;
		}

		public void PopulateFromCategory(Eecomerce.Entities.Category? category)
		{
			if(category == null)
			{
				return;
			}
			Id = category.Id;
			Name = category.Name;
			DisplayOrder = category.DisplayOrder;
		}
	}
}
