using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Data;
using AfishaApp.Models;
using AfishaApp.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AfishaApp.Services
{
    public interface IHomeService
    {
        Task<HomeVM> GetProductWithCategoryAsync();
        Task<Guid> UpdateTicketAsync(Afisha afisha);
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


        public async Task<Guid> UpdateTicketAsync(Afisha afisha)
        {
            afisha.CountTicket--;
            _db.Afishas.Update(afisha);
            await _db.SaveChangesAsync();
            return afisha.Id;
        }
    }
}
    