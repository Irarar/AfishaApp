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
        Afisha GetAfishaImageAsync(Afisha afisha);
        Task<Afisha> GetAfishaAsync(Guid afishaId);
        Task<Guid> EditAfishaAsync(Afisha afisha) ;
        Task<Guid> CreateAfishaSync(Afisha afisha);
        Task DeleteAfishaAsync(Guid afishaId);
    }

    public class AfishaService : IAfishaService
    {
        private readonly AppDbContext _db;

        public AfishaService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Afisha>> GetAllAfishasAsync()
        {
            return await _db.Afishas
                .Include(c => c.Category)
                .ThenInclude(c => c.Country)
                .ToListAsync();
        }

        public Afisha GetAfishaImageAsync(Afisha afisha)
        {
            return _db.Afishas.AsNoTracking().FirstOrDefault(a => a.Id == afisha.Id);
        }

        public async Task<Afisha> GetAfishaAsync(Guid afishaId)
        {
            return await _db.Afishas
                .Include(c => c.Category)
                .ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(a => a.Id == afishaId);
        }

        public async Task<Guid> EditAfishaAsync(Afisha afisha)
        {
             _db.Update(afisha);
            await _db.SaveChangesAsync();
            return afisha.Id;
        }

        public async Task<Guid> CreateAfishaSync(Afisha afisha)
        {
            await _db.AddAsync(afisha);
            await _db.SaveChangesAsync();
            return afisha.Id;
        }

        public async Task DeleteAfishaAsync(Guid afishaId)
        {
            _db.Remove(await _db.Afishas.FirstOrDefaultAsync(a => a.Id == afishaId));
            await _db.SaveChangesAsync();
        }
    }
}
