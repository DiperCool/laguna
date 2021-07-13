using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Db;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Models;
using Tools;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        Context _context;

        IWebHostEnvironment _appEnvironment;

        public CategoryService(Context context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task ChangeCategory(ChangeCategoryModel model)
        {
            Category category = await GetCatagory(model.Id);
            category.Name = model.Name;
            if(model.File!=null){
                SaveFile file = new SaveFile();
                string path = await file.Save(model.File, _appEnvironment.WebRootPath);
                category.IconUrl=path;
            }
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

        }

        public async Task<Category> CreateCategory(CreateCategoryModel model)
        {
            Category category = new Category{Name=model.Name};
            SaveFile file = new SaveFile();
            string path = await file.Save(model.File, _appEnvironment.WebRootPath);
            category.IconUrl=path;
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

        public async Task<Category> GetCategoryByName(string name)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x=>x.Name==name);
        }

        public async Task<Category> GetFirstCategory()
        {
            return await _context.Categories.AsNoTracking().OrderBy(x=>x.Id).FirstAsync();
        }

        private async Task<Category> GetCatagory(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}