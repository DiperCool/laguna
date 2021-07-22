using System.Threading.Tasks;
using Filters;
using Interfaces;
using Laguna.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;

namespace Controllers
{
    [UserHaveSecretFilterAtrribute]
    public class CategoryController : Controller
    {
        ICategoryService _service;
        IMemoryCache _memoryCache;

        public CategoryController(ICategoryService service, IMemoryCache memoryCache)
        {
            _service = service;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromForm] CreateCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            _memoryCache.Remove(CacheKeys.Categories);
            return Ok(await _service.CreateCategory(model));
        } 
    
        [HttpPost]
        public async Task<IActionResult> ChangeCategory([FromForm] ChangeCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            _memoryCache.Remove(CacheKeys.Categories);
            await _service.ChangeCategory(model);
            return Ok();
        }
      
        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            _memoryCache.Remove(CacheKeys.Categories);
            await _service.Delete(model.Id);
            return Ok();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}