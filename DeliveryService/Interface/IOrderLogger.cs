using DeliveryService.Models;

namespace DeliveryService.Interface
{
   
        public interface IOrderLogger
        {
            void LogOrderCreated(Order order);
            void LogOrderFiltered(string district, DateTime startTime, int orderCount);
        }

    
}
