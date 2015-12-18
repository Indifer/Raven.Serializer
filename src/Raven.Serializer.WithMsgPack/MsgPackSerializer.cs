using MsgPack.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithMsgPack
{
    public class MsgPackSerializer : IDataSerializer
    {
        private static Dictionary<Type, IMessagePackSerializer> msgPackserializers = new Dictionary<Type, IMessagePackSerializer>();
        private static readonly Encoding encoding = Encoding.UTF8;
        
        public byte[] Serialize(object obj)
        {
            if (obj is string)
            {
                return encoding.GetBytes(obj.ToString());
            }
            Type t = obj.GetType();

            IMessagePackSerializer serializer = null;
            //var serializer = MessagePackSerializer.Get(t);
            if (!msgPackserializers.ContainsKey(t))
            {
                serializer = MessagePackSerializer.Get(t);
                msgPackserializers[t] = serializer;
            }
            else
            {
                serializer = msgPackserializers[t];
            }
            
            using (var byteStream = new MemoryStream())
            {
                serializer.Pack(byteStream, obj);
                return byteStream.ToArray();
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            Type t = typeof(T);
            if (t == typeof(string))
            {
                return (T)Convert.ChangeType(encoding.GetString(data), t);
            }
            IMessagePackSerializer serializer = null;
            if (!msgPackserializers.ContainsKey(t))
            {
                serializer = MessagePackSerializer.Get<T>();
                msgPackserializers[t] = serializer;
            }
            else
            {
                serializer = msgPackserializers[t];
            }

            using (var byteStream = new MemoryStream(data))
            {
                return ((MessagePackSerializer<T>)serializer).Unpack(byteStream);
            }
        }
    }
}
