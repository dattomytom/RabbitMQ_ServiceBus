using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppRebbitMQTrigger
{
    public class FunctionProcessProductMQ
    {
        private readonly ILogger _logger;

        public FunctionProcessProductMQ(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FunctionProcessProductMQ>();
        }

        [Function("Function1")]
        public void Run([RabbitMQTrigger("order", ConnectionStringSetting = "HostName:localhost")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
