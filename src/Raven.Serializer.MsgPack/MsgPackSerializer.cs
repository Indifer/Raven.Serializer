using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.MsgPack
{
    public class MsgPackSerializer : IDataSerializer
    {
        public MsgPackSerializer(Action<SerializerRepository> customSerializerRegistrar = null, System.Text.Encoding encoding = null)
        {
            if (customSerializerRegistrar != null)
            {
                customSerializerRegistrar(SerializationContext.Default.Serializers);
            }

            if (encoding == null)
            {
                this.encoding = System.Text.Encoding.UTF8;
            }
        }

        private readonly System.Text.Encoding encoding;

        public T Deserialize<T>(byte[] data)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(encoding.GetString(data), typeof(T));
            }
            var serializer = MessagePackSerializer.Get<T>();

            using (var byteStream = new MemoryStream(serializedObject))
            {
                return serializer.Unpack(byteStream);
            }
        }

        public Task<object> DeserializeAsync(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> SerializeAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
