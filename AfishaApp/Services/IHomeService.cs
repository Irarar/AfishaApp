using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Data;
using AfishaApp.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AfishaApp.Services
{
    public interface IHomeService
    {
        Task<HomeVM> GetProductWithCategoryAsync();
        DetailsVM DetailsAsync(Guid id);
    }

    public class HomeService : IHomeService
    {
        private readonly AppDbContext _db;

        public HomeService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<HomeVM> GetProductWithCategoryAsync()
        {
            return new HomeVM
            {
                Afishas = await _db.Afishas.Include(u => u.Category).ToListAsync(),
                Categories = await _db.Categories.ToListAsync()
            };
        }

        public DetailsVM DetailsAsync(Guid id)
        {
            return new DetailsVM
            {
                Afisha = _db.Afishas
                    .Include(u => u.Category)
                    .Where(u => u.Id == id)
                    .FirstOrDefault(u => u.Id == id),
                ExistsInCart = false
            };
        }
    }
}
    