using MsgPack.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.MsgPack2
{
    public class MsgPackSerializer : IDataSerializer
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public T Deserialize<T>(byte[] data)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(encoding.GetString(data), typeof(T));
            }
            var serializer = MessagePackSerializer.Get<T>();

            using (var byteStream = new MemoryStream(data))
            {
                return serializer.Unpack(byteStream);
            }
        }        

        public byte[] Serialize(object obj)
        {
            if (obj is string)
            {
                return encoding.GetBytes(obj.ToString());
            }

            var serializer = MessagePackSerializer.Get(obj.GetType());

            using (var byteStream = new MemoryStream())
            {
                serializer.Pack(byteStream, obj);
                return byteStream.ToArray();
            }
        }
    }
}
