using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        Context _context;

        public CategoryService(Context context)
        {
            _context = context;
        }

        public async Task ChangeName(string name, int id)
        {
            Category category = await GetCatagory(id);
            category.Name = name;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

        }

        public async Task<Category> CreateCategory(string name)
        {
            Category category = new Category{Name=name};
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
            Category category = await GetCatagory(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            var res = await _context.Categories.AsNoTracking().OrderBy(x=>x.Id).ToListAsync();
            return res;
        }
        private async Task<Category> GetCatagory(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}