using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Data;
using AfishaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AfishaApp.Services
{
    public interface IAfishaService
    {
        Task<IEnumerable<Afisha>> GetAllAfishasAsync();
        Task<Afisha> GetAfishaAsync(Guid afishaId);
    }

    public class AfishaService : IAfishaService
    {
        private readonly AppDbContext _db;
        public async Task<IEnumerable<Afisha>> GetAllAfishasAsync()
        {
            return await _db.Afishas
                .Include(c => c.Category)
                .ThenInclude(c => c.Country)
                .ToListAsync();
        }

        public async Task<Afisha> GetAfishaAsync(Guid afishaId)
        {
            return await _db.Afishas
                .Include(c => c.Category)
                .FirstOrDefaultAsync(a => a.Id == afishaId);
        }
    }
}
