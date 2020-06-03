using Autofac;
using EasyNetQ;

namespace ComunicationWpfAngular.Api
{
    public class ApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var bus = RabbitHutch.CreateBus("host=localhost;virtualHost=/;username=guest;password=guest", r => r.Register<ITypeNameSerializer, CustomEasyNetQTypeNameSerializer>());
            builder.RegisterInstance(bus).SingleInstance();
            builder.RegisterType<MessageReceiver>().As<IMessageReceiver>();
        }
    }


}
