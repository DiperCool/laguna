using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(string name);
        Task ChangeName(string name, int id);
        Task Delete(int id);
        Task<List<Category>> GetCategories();

    }
}