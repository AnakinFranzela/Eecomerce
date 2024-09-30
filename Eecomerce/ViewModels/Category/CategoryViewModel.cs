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
		public int DisplayOrder { get; set; }
	}
}
