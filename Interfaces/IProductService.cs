using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Models;

namespace Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateProduct(CreateProductModel model);
        Task<Product> UpdateProduct(UpdateProductModel model);
        Task DeleteProduct(int id);
        Task<List<Product>> GetProductsByCategory(int idCategory);
        Task<List<Product>> GetProductFilter(string name, int? idCategory);
        Task<Product> GetProductById(int id);
        Task<double?> GetCostsProductById(int id);
    }
}