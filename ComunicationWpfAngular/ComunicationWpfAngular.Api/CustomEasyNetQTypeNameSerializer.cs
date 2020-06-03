using EasyNetQ;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComunicationWpfAngular.Api
{
    public class CustomEasyNetQTypeNameSerializer : ITypeNameSerializer
    {
        private readonly ConcurrentDictionary<string, Type> deserializedTypes = new ConcurrentDictionary<string, Type>();

        public Type DeSerialize(string typeName)
        {
            if (deserializedTypes.ContainsKey(typeName))
                return deserializedTypes[typeName];
            else
                throw new EasyNetQException("Blah blah blah, type does not exist.");
        }

        private readonly ConcurrentDictionary<Type, string> serializedTypes = new ConcurrentDictionary<Type, string>();

        public string Serialize(Type type)
        {
            return serializedTypes.GetOrAdd(type, t =>
            {
                return t.FullName;
            });
        }
    }
}
