using System;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class ViewBagCategoriesFilterAttribute : Attribute, IAsyncActionFilter
    {
        ICategoryService _service;

        public ViewBagCategoriesFilterAttribute(ICategoryService service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ((Controller)context.Controller).ViewBag.Categories = await _service.GetCategories();
            await next();
        }
    }
}