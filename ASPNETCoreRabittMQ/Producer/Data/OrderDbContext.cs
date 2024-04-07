using Microsoft.EntityFrameworkCore;
using Producer.Data.Entity;

namespace Producer.Data
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> opts): base(opts) 
        {
            
        }
        public DbSet<Order> Orders { get; set; }
    }
}
