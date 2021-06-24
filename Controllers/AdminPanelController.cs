using Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Controllers
{
    
    public class AdminPanelController : Controller
    {
        private IConfiguration _config;

        public AdminPanelController(IConfiguration config)
        {
            _config = config;
        }
        [UserHaveSecretFilterAtrribute]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [UserHaveSecretFilterAtrribute]
        [HttpGet]
        public IActionResult Category()
        {
            return View();
        }
        [UserHaveSecretFilterAtrribute]
        [HttpGet]
        public IActionResult Product()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] Models.AdminPanelLoginModel model)
        {
            if(model.Login!=_config.GetValue<string>("AdminPanel:Login") && model.Password!=_config.GetValue<string>("AdminPanel:Password")) 
                return Redirect("~/");
            HttpContext.Session.SetString("SecretCodeAdminPanel", _config.GetValue<string>("AdminPanel:SecretCode"));
            return Redirect("~/AdminPanelProduct/Products");
        }

    }
}