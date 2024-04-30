using Microsoft.AspNetCore.Mvc;
using Producer.Dtos;
using Producer.Service;

namespace Producer.Controllers
{
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost("/Order")]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            //for(int i = 0; i < 100; i++)
            //{
                await orderService.SaveOrder(orderDto);
            //}
            
            return Ok(orderService.GetAllOrder());
        }
    }
}
