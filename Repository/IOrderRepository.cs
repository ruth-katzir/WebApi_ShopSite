using entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addOrderAsync(Order order);
        Task<Order> getOrderAsync(int id);
    }
}