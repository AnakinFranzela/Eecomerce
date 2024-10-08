using Microsoft.AspNetCore.Mvc;
using Eecomerce.Entities;
using Eecomerce.Services.IServices;
using Eecomerce.ViewModels.Category;
using Eecomerce.Helpers;

namespace Ecom.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _categoryService.GetCategoryList();
            return View(categoryList);
        }

   //     public IActionResult Upsert(int? id)
   //     {
   //         CategoryViewModel viewModel = new CategoryViewModel();
   //         if (id == null)
   //         {
			//	return View(viewModel);
			//}

   //         Category? category = _categoryService.GetCategoryById(id);

   //         if(category == null)
   //         {
   //             TempData["error"] = "Category with id " + id + " not found!";
   //             return RedirectToAction("Index");
   //         }
   //         viewModel.PopulateFromCategory(category);
   //         return View(viewModel);
   //     }

        public IActionResult Create()
        {
            CategoryViewModel viewModel = new CategoryViewModel();
                return View(viewModel);
        }

        public IActionResult Update(int id)
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            Category? category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                TempData["error"] = "Category with id " + id + " not found!";
                return RedirectToAction("Index");
            }
            viewModel.PopulateFromCategory(category);
            return View(viewModel);
        }

  //      [HttpPost]
  //      [ValidateAntiForgeryToken]
  //      public IActionResult Upsert(CategoryViewModel viewModel)
  //      {
  //          Category category = new Category();

  //          if (viewModel.Id == null && ModelState.IsValid)
  //          {
  //              viewModel.PopulateCategory(category);
  //              if (_categoryService.AddCategory(category))
  //              {
  //                  TempData["success"] = "Category was created successfully!";
  //                  return RedirectToAction("Index");
  //              }
  //              TempData["error"] = "Unable to create category!";
  //          }
  //          else
  //          {
  //              if (ModelState.IsValid)
  //              {
  //                  viewModel.PopulateCategory(category);
  //                  if(_categoryService.UpdateCategory(category))
  //                  {
  //                      TempData["success"] = "Category was updated successfully!";
  //                      return RedirectToAction("Index");
  //                  }
  //                  TempData["error"] = "Unable to update category!";
  //              }
  //          }
		//	return View(viewModel);
		//}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(CategoryViewModel viewModel)
        {
			Category category = new Category();

			if (ModelState.IsValid)
			{
				viewModel.PopulateCategory(category);
				if (_categoryService.UpdateCategory(category))
				{
					TempData["success"] = "Category was updated successfully!";
					return RedirectToAction("Index");
				}
				TempData["error"] = "Unable to update category!";
			}

            return View(viewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            _categoryService.SetModelStateDictionary(new ModelStateWrapper(ModelState));
			Category category = new Category();

			viewModel.PopulateCategory(category);
			if (_categoryService.AddCategory(category))
			{
				TempData["success"] = "Category was created successfully!";
				return RedirectToAction("Index");
			}
			TempData["error"] = "Unable to create category!";

			return View(viewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (_categoryService.DeleteCategory(id))
            {
                TempData["success"] = "Category was deleted successfully";
            }
            else
            {
                TempData["error"] = "Unable to delete category";
            }
            return RedirectToAction("Index");
        }
    }
}
