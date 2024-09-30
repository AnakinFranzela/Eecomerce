﻿using Microsoft.AspNetCore.Mvc;
using Eecomerce.Entities;
using Eecomerce.Services.IServices;
using Eecomerce.ViewModels.Category;

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

        public IActionResult Upsert()
        {
            CategoryViewModel viewModel = new CategoryViewModel();
            return View(viewModel);
        }
    }
}