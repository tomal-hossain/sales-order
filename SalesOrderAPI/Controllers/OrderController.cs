using API.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;

namespace SalesOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Route("all")]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderService.GetAllAsync();
            return StatusCode(response.StatusCode, response.Result);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> AddOrder(OrderViewModel model)
        {
            var response = await _orderService.SaveAsync(model);
            return StatusCode(response.StatusCode, response);
        }

		[HttpDelete, Route("remove/{id}")]
		public async Task<IActionResult> RemoveOrder(int id)
		{
			var response = await _orderService.RemoveAsync(id);
			return StatusCode(response.StatusCode, response);
		}
	}
}
