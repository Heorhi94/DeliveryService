using DeliveryService.Models;

namespace DeliveryService.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> FilterOrdersAsync(string district, DateTime startTime);
        Task<Order> CreateOrderAsync(Order order);
        Task<IEnumerable<string>> GetDistrictsAsync();
    }
}
