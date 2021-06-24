using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Tools;

namespace Filters
{
    class UserHaveSecretFilterAtrribute : TypeFilterAttribute
    {
        public UserHaveSecretFilterAtrribute():
        base(typeof(UserHaveSecretFilter))
        {
            
            this.Arguments= new object[]{};
        }

        private class UserHaveSecretFilter : Attribute, IActionFilter
        {
            private IConfiguration _config;
            public UserHaveSecretFilter(IConfiguration config)
            {
                _config = config;
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                CheckUsersSecret check = new CheckUsersSecret();
                if(!check.Check(context.HttpContext,_config.GetValue<string>("AdminPanel:SecretCode") ))
                {
                    

                    context.Result= new RedirectToActionResult("login", "AdminPanel", new Object{});
                    return;
                }
            
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                
            }
        }
    }
}
