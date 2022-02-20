using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Models;
using AfishaApp.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AfishaApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICountyService _countryService;

        public CategoryController(ICategoryService categoryService, ICountyService countryService)
        {
            _categoryService = categoryService;
            _countryService = countryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllCategoryAsync());
        }

        public async Task<IActionResult> Create(Guid categoryId)
        {
            ViewBag.CountryId = 
                new SelectList(await _countryService.GetAllCountryAsync(),"Id","Name");
            
            return View(await _categoryService.GetCategoryAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid categoryId)
        {
            ViewBag.CountryId =
                new SelectList(await _countryService.GetAllCountryAsync(), "Id", "Name");
            return View(await _categoryService.GetCategoryAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var categoryId = await _categoryService.EditCategoryAsync(category);
            return RedirectToAction("Index", new { categoryId });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            await _categoryService.DeleteCategoryAsync(categoryId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid categoryId)
        {
            ViewBag.CountryId =
                new SelectList(await _countryService.GetAllCountryAsync(), "Id", "Name");

            return View(await _categoryService.GetCategoryAsync(categoryId));
        }
    }

}
