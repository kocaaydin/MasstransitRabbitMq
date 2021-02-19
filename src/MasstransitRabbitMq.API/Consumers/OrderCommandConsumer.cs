using MassTransit;
using MasstransitRabbitMq.Contracts;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MasstransitRabbitMq.API.Consumers
{
    public class OrderCommandConsumer : IConsumer<IOrderCommand>
    {
        public Task Consume(ConsumeContext<IOrderCommand> context)
        {
            var message = context.Message;
            Debug.WriteLine(message.Description);

            context.Publish<IOrderCreatedEvent>(new 
            {
                OrderId = Guid.NewGuid()
            });

            return Task.CompletedTask;
        }
    }
}
