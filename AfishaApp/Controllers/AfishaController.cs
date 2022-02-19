using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Models;
using AfishaApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AfishaApp.Controllers
{
    public class AfishaController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IAfishaService _afishaService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AfishaController(IAfishaService afishaService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _afishaService = afishaService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
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
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            string upload = webRootPath + WebConst.ImagePath;
            string FileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, FileName + extension), FileMode.Create))
            {
                await files[0].CopyToAsync(fileStream);
            }
            afisha.Image = FileName + extension;

            var afishaId = await _afishaService.CreateAfishaSync(afisha);
            return RedirectToAction("Index", new { afishaId });

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
