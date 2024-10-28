using DeliveryService.Models;
using DeliveryService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DeliveryService.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

        public async Task<IActionResult> Filter()
        {
            ViewBag.Districts = new SelectList(await _orderService.GetDistrictsAsync());
            return View(new FilterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Filter(FilterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Districts = new SelectList(await _orderService.GetDistrictsAsync());
                return View(model);
            }

            var filteredOrders = await _orderService.FilterOrdersAsync(model.District, model.StartTime);
            return View("FilterResults", filteredOrders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            try
            {
                await _orderService.CreateOrderAsync(order);
                TempData["Success"] = "Order created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                ModelState.AddModelError("", "Error creating order. Please try again.");
                return View(order);
            }
        }
    }
}