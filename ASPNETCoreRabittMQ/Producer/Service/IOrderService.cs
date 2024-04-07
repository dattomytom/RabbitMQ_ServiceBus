using Producer.Data.Entity;
using Producer.Dtos;

namespace Producer.Service
{
    public interface IOrderService
    {
        Task SaveOrder(OrderDto orderDto);
        List<Order> GetAllOrder();
    }
}
