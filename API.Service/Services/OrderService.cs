using API.Domain.Entity;
using API.Service.DB;
using API.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedModels.Models;

namespace API.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, ILogger<OrderService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseModel> GetAllAsync()
        {
            try
            {
                var orders = await _context.Orders.Include(o => o.Windows).ThenInclude(w => w.SubElements).ToArrayAsync();
                var mappedOrders = _mapper.Map<IList<OrderViewModel>>(orders);
                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = mappedOrders
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while fetching orders");
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = ex.Message
                };
            }
        }

        public async Task<ResponseModel> SaveAsync(OrderViewModel order)
        {
            try
            {
                var newOrder = _mapper.Map<Order>(order);
                newOrder.CreationDate= DateTime.UtcNow;

                await _context.Orders.AddAsync(newOrder);
                await _context.SaveChangesAsync();

                var mappedOrder = _mapper.Map<OrderViewModel>(newOrder);
                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Result = mappedOrder
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while inserting new order");
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Result = ex.Message
                };
            }
        }

		public async Task<ResponseModel> RemoveAsync(int id)
        {
			try
			{
                var order = await _context.Orders.FindAsync(id);

                if(order == null)
                {
					return new ResponseModel
					{
						IsSuccess = false,
						StatusCode = 404,
						Result = "Order not found!"
					};
				}

                _context.Orders.Remove(order);
				await _context.SaveChangesAsync();

				return new ResponseModel
				{
					IsSuccess = true,
					StatusCode = 200,
					Result = "Successfully removed"
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error while deleting order");
				return new ResponseModel
				{
					IsSuccess = false,
					StatusCode = 500,
					Result = ex.Message
				};
			}
		}

	}
}
