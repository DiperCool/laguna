using System.Threading.Tasks;
using Entities;
using Models;

namespace Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task<ViewOrdersModel> GetOrders(int page);
        Task<Order> GetOrderById(int id);
    }
}