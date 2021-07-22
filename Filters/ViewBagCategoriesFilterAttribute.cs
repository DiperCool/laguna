using System;
using System.Threading.Tasks;
using Interfaces;
using Laguna.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Tools;

namespace Filters
{
    public class ViewBagCategoriesFilterAttribute : Attribute, IAsyncActionFilter
    {
        ICategoryService _service;
        IConfiguration _config;
        IMemoryCache _cache;

        public ViewBagCategoriesFilterAttribute(ICategoryService service, IConfiguration config, IMemoryCache cache)
        {
            _service = service;
            _config = config;
            _cache = cache;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ((Controller)context.Controller).ViewBag.Categories = await _cache.GetOrCreate(CacheKeys.Categories, async (entry)=>{
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return await _service.GetCategories();
            });
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