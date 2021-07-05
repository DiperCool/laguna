using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IEmailService
    {
        Task Send(string content, int id);
    }
}