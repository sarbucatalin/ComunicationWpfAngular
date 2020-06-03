using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComunicationWpfAngular.Contracts;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComunicationWpfAngular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IBus _bus;

        public MessageController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task SendMessage(MessageContract message)
        {
            await _bus.SendAsync<MessageContract>("ApiToWpf", message);
        }
    }
}
