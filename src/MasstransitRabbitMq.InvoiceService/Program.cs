using MassTransit;
using MasstransitRabbitMq.Contracts;
using System;

namespace MasstransitRabbitMq.InvoiceService
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = BusConfigurator.ConfigureBus((cfg) =>
            {
                cfg.ReceiveEndpoint(RabbitMqConsts.InvoiceService, e =>
                {
                    e.Consumer<OrderCreatedEventConsumer>();
                });
            });

            bus.StartAsync();
            Console.WriteLine("Listening for Demand registered events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
