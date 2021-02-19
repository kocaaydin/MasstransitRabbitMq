using MassTransit;
using MasstransitRabbitMq.Contracts;
using System;
using System.Threading.Tasks;

namespace MasstransitRabbitMq.InvoiceService
{
    public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedEvent>
    {
        public Task Consume(ConsumeContext<IOrderCreatedEvent> context)
        {
            Console.WriteLine(context.Message.OrderId.ToString());
            return Task.CompletedTask;
        }
    }
}
