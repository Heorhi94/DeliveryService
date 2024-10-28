using DeliveryService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(ApplicationDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.OrderByDescending(o => o.DeliveryTime).ToListAsync();
        }

        public async Task<IEnumerable<Order>> FilterOrdersAsync(string district, DateTime startTime)
        {
            try
            {
                _logger.LogInformation($"Filtering orders for district {district} starting from {startTime}");

                var endTime = startTime.AddMinutes(30);

                return await _context.Orders
                    .Where(o => o.District.Equals(district) &&
                               o.DeliveryTime >= startTime &&
                               o.DeliveryTime <= endTime)
                    .OrderBy(o => o.DeliveryTime)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error filtering orders");
                throw;
            }
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            try
            {
                _logger.LogInformation($"Creating new order for district {order.District}");

                order.Id = Guid.NewGuid().ToString();
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetDistrictsAsync()
        {
            return await _context.Orders
                .Select(o => o.District)
                .Distinct()
                .ToListAsync();
        }
    }
}
