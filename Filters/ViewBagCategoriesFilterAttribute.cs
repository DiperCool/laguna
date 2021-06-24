using System;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Tools;

namespace Filters
{
    public class ViewBagCategoriesFilterAttribute : Attribute, IAsyncActionFilter
    {
        ICategoryService _service;
        IConfiguration _config;

        public ViewBagCategoriesFilterAttribute(ICategoryService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ((Controller)context.Controller).ViewBag.Categories = await _service.GetCategories();
            string path = context.HttpContext.Request.Path.Value.ToLower();
            CheckUsersSecret check = new CheckUsersSecret();

            if(path.Contains("adminpanel") && check.Check(context.HttpContext,_config.GetValue<string>("AdminPanel:SecretCode")))
            {
                ((Controller)context.Controller).ViewBag.IsAdmin = true;
            }
            else
            {
                ((Controller)context.Controller).ViewBag.IsAdmin = false;
            }
            await next();
        }
    }
}