using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfishaApp.Data;
using AfishaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AfishaApp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        Task CreateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Guid categoryId);
        Task<Guid> EditCategoryAsync(Category category);

    }

    class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;

        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _db.Categories.Include(c => c.Country).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid categoryId)
        {
            return await _db.Categories.Include(c => c.Country).FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            _db.Remove(await _db.Categories.FirstOrDefaultAsync(c => c.Id == categoryId));
            await _db.SaveChangesAsync();
        }

        public async Task<Guid> EditCategoryAsync(Category category)
        {
            _db.Update(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }
    }
}
