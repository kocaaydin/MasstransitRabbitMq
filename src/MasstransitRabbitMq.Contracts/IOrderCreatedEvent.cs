using System;

namespace MasstransitRabbitMq.Contracts
{
    public interface IOrderCreatedEvent
    {
        public Guid OrderId { get; set; }
    }
}
