
using Microsoft.EntityFrameworkCore;
using Producer.Data;
using Producer.RabbitMQ;
using Producer.RabbitMQ.Connection;
using Producer.Service;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<OrderDbContext>(opt =>
            {
                opt.UseInMemoryDatabase("ASPNetCoreRabbitMQ");
            });

            builder.Services.AddScoped<IOrderService,OrderService>();
            builder.Services.AddSingleton<IRabbitMqConnection>(new RabbitMqConnection());
            builder.Services.AddScoped<IMessageProducer, RabbitMqProducer>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
