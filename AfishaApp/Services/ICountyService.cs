using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Data;
using AfishaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AfishaApp.Services
{
    public interface ICountyService
    {
        Task<Country> GetCountryAsync(Guid countryId);
        Task<IEnumerable<Country>> GetAllCountryAsync();
    }

    public class CountryService : ICountyService
    {
        private readonly AppDbContext _db;

        public CountryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Country> GetCountryAsync(Guid countryId)
        {
            return await _db.Country.FirstOrDefaultAsync(c => c.Id == countryId);
        }

        public async Task<IEnumerable<Country>> GetAllCountryAsync()
        {
            return await _db.Country.ToListAsync();
        }
    }
}
