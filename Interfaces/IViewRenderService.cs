using System.Threading.Tasks;

namespace Interfaces
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);

    }
}