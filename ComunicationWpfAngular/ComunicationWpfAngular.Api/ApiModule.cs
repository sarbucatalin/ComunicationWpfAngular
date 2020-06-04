using Autofac;
using EasyNetQ;
using ComunicationWpfAngular.Contracts;

namespace ComunicationWpfAngular.Api
{
    public class ApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var bus = RabbitHutch.CreateBus("host=localhost;virtualHost=/;username=guest;password=guest",
                serviceRegister => serviceRegister.Register<ISerializer>(serviceProvider => new MyJsonSerializer())
                );
            builder.RegisterInstance(bus).SingleInstance();
            builder.RegisterType<MessageReceiver>().As<IMessageReceiver>();
        }
    }


}
