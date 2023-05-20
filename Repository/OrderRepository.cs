using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        MyShopSite325593952Context _DbContext;

        public OrderRepository(MyShopSite325593952Context dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Order> addOrderAsync(Order order)
        {
            await _DbContext.Orders.AddAsync(order);
            await _DbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> getOrderAsync(int id)
        {
            var orderWithItems = await _DbContext.Orders.Include(order => order.OrderItems).Where(ord => ord.Id == id).ToListAsync();
            return orderWithItems[0];
        }

    }
}
