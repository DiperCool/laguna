using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Tools
{
    public class CheckUsersSecret
    {
        public bool Check(HttpContext context, string secret)
        {
            if(!context.Session.Keys.Contains("SecretCodeAdminPanel"))
            {
                
                return false;
            }
            if(context.Session.GetString("SecretCodeAdminPanel")!= secret)
            {
                
                return false;
            }
            return true;
        }
    }
}