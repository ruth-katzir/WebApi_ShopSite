using entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> addOrderAsync(Order order);
        Task<Order> getOrderAsync(int id);
    }
}