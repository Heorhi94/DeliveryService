using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DeliveryService.Models
{
    public class FilterViewModel
    {
        [Required]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
    }
}
