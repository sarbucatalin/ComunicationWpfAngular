using ComunicationWpfAngular.Api.Hubs;
using ComunicationWpfAngular.Contracts;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ComunicationWpfAngular.Api
{
    public class MessageReceiver : IMessageReceiver
    {
        private readonly IHubContext<SignalRHub> _hubContext;

        public MessageReceiver(IHubContext<SignalRHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Execute(MessageContract message)
        {
            await _hubContext.Clients.All.SendAsync("SignalRMessageReceived", message.Value);
        }
    }
}
