using System.Threading.Tasks;
using Filters;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _service.GetCategories());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategories([FromBody] CreateCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            return Ok(await _service.CreateCategory(model.Name));
        } 
        [UserHaveSecretFilterAtrribute]
        [HttpPost]
        public async Task<IActionResult> ChangeCategoriesName([FromBody] ChangeCategoriesNameModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            await _service.ChangeName(model.Name, model.Id);
            return Ok();
        }
        [UserHaveSecretFilterAtrribute]
        [HttpPost]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryModel model)
        {   
            if(!ModelState.IsValid) return BadRequest(model);
            await _service.Delete(model.Id);
            return Ok();
        }

        [HttpGet]
        [UserHaveSecretFilterAtrribute]
        public IActionResult Index()
        {
            return View();
        }


    }
}