using MassTransit;
using MasstransitRabbitMq.API.Commands;
using MasstransitRabbitMq.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MasstransitRabbitMq.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;
        public OrderController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateQrderCommand command)
        {
            var uri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.OrderServiceQueue}");

            var endPoint = await _bus.GetSendEndpoint(uri);

            await endPoint.Send<IOrderCommand>(new
            {
                Description = $"{command.Description} {DateTime.Now.ToString()}"
            });

            return Ok();
        }
    }
}
