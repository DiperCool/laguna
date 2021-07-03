using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Models;

namespace Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(CreateCategoryModel model);
        Task ChangeName(string name, int id);
        Task Delete(int id);
        Task<List<Category>> GetCategories();
        Task<Category> GetFirstCategory();
        Task<Category> GetCategoryByName(string name);

    }
}