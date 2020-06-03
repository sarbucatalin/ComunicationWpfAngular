using Autofac;
using ComunicationWpfAngular.Contracts;
using EasyNetQ;

namespace ComunicationWpfAngular.Api
{
    public class QueueListeners : IStartable
    {
        private readonly IBus _bus;
        private readonly IComponentContext _resolver;

        public QueueListeners(IBus bus, IComponentContext resolver)
        {
            _bus = bus;
            _resolver = resolver;
        }


        public void Start()
        {
            _bus.Receive<string>("WpfToApi",
                message => _resolver.Resolve<IMessageReceiver>().Execute(message));
        }
    }
}
 