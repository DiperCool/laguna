using System.Threading.Tasks;
using Filters;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [UserHaveSecretFilterAtrribute]
    public class CategoryController : Controller
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromForm] CreateCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            return Ok(await _service.CreateCategory(model));
        } 
    
        [HttpPost]
        public async Task<IActionResult> ChangeCategoriesName([FromBody] ChangeCategoriesNameModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            await _service.ChangeName(model.Name, model.Id);
            return Ok();
        }
      
        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
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