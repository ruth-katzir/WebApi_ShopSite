using entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository repository;
        IProductRepository productRepository;
        ILogger<OrderService> logger;

        public OrderService(IOrderRepository repository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public async Task<Order> addOrderAsync(Order order)
        {
            int orderSum = 0;
            foreach (var orderItem in order.OrderItems)
            {
                orderSum += orderItem.Quantity * await productRepository.getProductPriceByProductId(orderItem.ProductId);  
            }
            if (order.OrderSum != orderSum)
            {
                logger.LogInformation($"unmatch orderSum userId: {order.UserId} at: {DateTime.UtcNow.ToLongTimeString()}");
            }
            order.OrderSum = orderSum;
            return await repository.addOrderAsync(order);
        }

        public async Task<Order> getOrderAsync(int id)
        {
            return await repository.getOrderAsync(id);
        }
    }
}
