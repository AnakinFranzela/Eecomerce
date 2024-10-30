using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eecomerce.ViewModels.Category
{
	public class CategoryViewModel
	{
        public int? Id { get; set; }

        [Required(ErrorMessage = "Полето \"Име\" е задължително!")]
        [DisplayName("Име")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Полето \"Ред на показване\" е задължително!")]
        [DisplayName("Ред на показване")]
        public int DisplayOrder { get; set; }

        public void PopulateCategory(Eecomerce.Entities.Category categoty)
        {
            if (Id != null && Id != 0)
                categoty.Id = (int)Id;

            categoty.Name = Name;
            categoty.DisplayOrder = DisplayOrder;
        }

        public void PopulateFromCategory(Eecomerce.Entities.Category? category)
        {
            if (category == null)
                return;

            Id = category.Id;
            Name = category.Name;
            DisplayOrder = category.DisplayOrder;
        }
	}
}
