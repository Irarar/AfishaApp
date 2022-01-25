using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Models;
using AfishaApp.Services;

namespace AfishaApp.Controllers
{
    public class AfishaController : Controller
    {
        private readonly IAfishaService _afishaService;

        public AfishaController(IAfishaService afishaService)
        {
            _afishaService = afishaService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _afishaService.GetAllAfishasAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Afisha afisha)
        {
            await _afishaService.CreateAfishaAsync(afisha);
            return RedirectToAction("Details");
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

    }
}
