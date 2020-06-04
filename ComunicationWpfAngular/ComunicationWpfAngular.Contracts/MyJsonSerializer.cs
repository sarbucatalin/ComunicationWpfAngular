using System;
using System.Text;
using EasyNetQ;
using Newtonsoft.Json;

namespace ComunicationWpfAngular.Contracts
{
    public class MyJsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        };

        
        public byte[] MessageToBytes(Type messageType, object message)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, serializerSettings));
        }

        public object BytesToMessage(Type messageType, byte[] bytes)
        {
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes), messageType, serializerSettings);
        }
    }
}
