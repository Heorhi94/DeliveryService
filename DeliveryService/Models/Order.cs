using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DeliveryService.Models
{
    public class Order
    {
        public string Id { get; set; }

        [Required]
        [Range(0.1, 1000)]
        public decimal Weight { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        [Display(Name = "Delivery Time")]
        public DateTime DeliveryTime { get; set; }
    }
}
