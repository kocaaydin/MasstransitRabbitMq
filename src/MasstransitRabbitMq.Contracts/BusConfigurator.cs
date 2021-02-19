using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace MasstransitRabbitMq.Contracts
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConsts.UserName);
                    hst.Password(RabbitMqConsts.Password);
                });

                registrationAction?.Invoke(cfg);
            });
        }
    }
}
