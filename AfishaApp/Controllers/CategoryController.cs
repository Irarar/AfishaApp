using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Models;
using AfishaApp.Services;

namespace AfishaApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllCategoryAsync());
        }

        public async Task<IActionResult> Create(Guid categoryId)
        {

            return View(await _categoryService.GetCategoryAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return RedirectToAction("Details");
        }

        public async Task<IActionResult> Edit(Guid categoryId)
        {
            return View(await _categoryService.GetCategoryAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var categoryId = await _categoryService.EditCategoryAsync(category);
            return RedirectToAction("Details", new { categoryId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return RedirectToAction("Index");
        }
    }
}
