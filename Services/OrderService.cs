using System.Linq;
using System.Threading.Tasks;
using Db;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class OrderService : IOrderService
    {
        Context _context;
        public OrderService(Context context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<ViewOrdersModel> GetOrders(int page)
        {

            int pageSize = 20;
            int count = await _context.Orders.CountAsync();
            var items = await _context.Orders.OrderByDescending(x=>x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new ViewOrdersModel{
                Orders = items,
                Page= new PageViewModel(count, page, pageSize)
            };
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.Include(x=>x.Products).ThenInclude(x=>x.Product).Include(x=>x.Promocode).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}