using DeliveryService.Interface;
using DeliveryService.Models;

namespace DeliveryService.Log
{
    public class OrderLogger : IOrderLogger
    {
        private readonly ILogger<OrderLogger> _logger;

        public OrderLogger(ILogger<OrderLogger> logger)
        {
            _logger = logger;
        }

        public void LogOrderCreated(Order order)
        {
            _logger.LogInformation("Order created: Id={Id}, Weight={Weight}, District={District}, DeliveryTime={DeliveryTime}",
                order.Id, order.Weight, order.District, order.DeliveryTime);
        }

        public void LogOrderFiltered(string district, DateTime startTime, int orderCount)
        {
            _logger.LogInformation("Filtered {OrderCount} orders for district {District} starting from {StartTime}",
                orderCount, district, startTime);
        }
    }
}
