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
    public class AfishaController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAfishaService _afishaService;

        public AfishaController(IAfishaService afishaService, ICategoryService categoryService)
        {
            _afishaService = afishaService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _afishaService.GetAllAfishasAsync());
        }

        public async Task<IActionResult> Create(Guid afishaId)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoryAsync(), "Id","Name");
            return View(await _afishaService.GetAfishaAsync(afishaId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Afisha afisha)
        {
            await _afishaService.CreateAfishaSync(afisha);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid afishaId)
        {
            return View(await _afishaService.GetAfishaAsync(afishaId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Afisha afisha)
        {
            var afishaId = await _afishaService.EditAfishaAsync(afisha);
            return RedirectToAction("Details", new {afishaId});
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid afishaId)
        {
            await _afishaService.DeleteAfishaAsync(afishaId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid afishaId)
        {
            ViewBag.CategoruId = new SelectList(await _categoryService.GetAllCategoryAsync(), "Id", "Name");
            return View(await _afishaService.GetAfishaAsync(afishaId));
        }
    }
}
