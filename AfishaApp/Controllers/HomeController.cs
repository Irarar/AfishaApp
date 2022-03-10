using AfishaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Data;
using AfishaApp.Services;
using AfishaApp.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AfishaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        private readonly IAfishaService _afishaService;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, AppDbContext db, IAfishaService afishaService)
        {
            _logger = logger;
            _homeService = homeService;
            _db = db;
            _afishaService = afishaService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _homeService.GetProductWithCategoryAsync());
        }


        public async Task<IActionResult> Details(Guid afishaId)
        {
            return View(await _afishaService.GetAfishaAsync(afishaId));
        }
        public async Task<IActionResult> UpdateTicket(Guid afishaId)
        {
            return View(await _afishaService.GetAfishaAsync(afishaId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTicket(Afisha afisha)
        {
            var afishaId = await _homeService.UpdateTicketAsync(afisha);
            return RedirectToAction("Details", new { afishaId });
        }
    }
}
