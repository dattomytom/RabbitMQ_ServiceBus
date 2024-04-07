using Producer.Data;
using Producer.Data.Entity;
using Producer.Dtos;
using Producer.RabbitMQ;

namespace Producer.Service
{
    public class OrderService:IOrderService
    {
        private readonly OrderDbContext _context;
        private readonly IMessageProducer _messageProducer;

        public OrderService(OrderDbContext context,IMessageProducer messageProducer)
        {
            _context = context;
            _messageProducer = messageProducer;
        }

        public List<Order> GetAllOrder()
        {
            return _context.Orders.Local.ToList<Order>();
        }

        public async Task SaveOrder(OrderDto orderDto)
        {
            var order = await Save(orderDto);
            if( order != null)
            {
                _messageProducer.SendMessage(order);
            }
        }
        private async Task<Order> Save(OrderDto orderDto)
        {
            var order = new Order();
            order.Price = orderDto.Price;
            order.Quantity = orderDto.Quantity;
            order.ProductName = orderDto.ProductName;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
