using System.Collections.Generic;
using System.Threading.Tasks;
using Db;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Hosting;
using Models;
using Tools;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductService : IProductService
    {
        IWebHostEnvironment _appEnvironment;
        Context _context;

        public ProductService(IWebHostEnvironment appEnvironment, Context context)
        {
            _appEnvironment = appEnvironment;
            _context = context;
        }

        public async Task<Product> CreateProduct(CreateProductModel model)
        {
            string path;
            if(model.File!=null)
            {
                path = await SaveFile.Save(model.File, _appEnvironment.WebRootPath);
            }
            else if(model.UrlPhoto!=null)
            {
                path=model.UrlPhoto;
            }
            else{
                throw new FileException("File not found");
            }

            Product product = new Product{ Name=model.Name, Excerpt= model.Excerpt, Description= model.Description, Cost= model.Cost, CategoryId= model.IdCategory, UrlPhoto= path };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<Product>> GetProductFilter(string name, int? idCategory)
        {
            IQueryable<Product> products = _context.Products.AsNoTracking();
            if(!string.IsNullOrEmpty(name))
            {
                products=products.Where(x=>x.Name.Contains(name));
            }
            if(idCategory!=null && idCategory!=0)
            {
                products=products.Where(x=>x.CategoryId==idCategory);
            }
            return await products.Include(x=>x.Category).OrderBy(x=>x.Id).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(int idCategory)
        {
            return await _context.Products.OrderBy(x=>x.Id).Where(x=>x.CategoryId==idCategory).ToListAsync();
        }

        public async Task<Product> UpdateProduct(UpdateProductModel model)
        {
            string path;
            
            if(model.File!=null)
            {
                path = await SaveFile.Save(model.File, _appEnvironment.WebRootPath);
            }
            else if(model.UrlPhoto!=null)
            {
                path=model.UrlPhoto;
            }
            else{
                throw new FileException("File not found");
            }
            Product product = new Product{ Id=model.Id, Name=model.Name, Excerpt= model.Excerpt, Description= model.Description, Cost= model.Cost, CategoryId= model.IdCategory, UrlPhoto= path };
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
    [System.Serializable]
    public class FileException : System.Exception
    {
        public FileException() { }
        public FileException(string message) : base(message) { }
        public FileException(string message, System.Exception inner) : base(message, inner) { }
        protected FileException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}