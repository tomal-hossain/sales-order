using SharedModels.Models;

namespace API.Service.Interfaces
{
    public interface IOrderService
    {
        Task<ResponseModel> SaveAsync(OrderViewModel order);
        Task<ResponseModel> GetAllAsync();
		Task<ResponseModel> RemoveAsync(int id);
	}
}
