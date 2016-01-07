using MsgPack.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithMsgPack
{
    /// <summary>
    /// 
    /// </summary>
    public class MsgPackSerializer : IDataSerializer
    {
        private static Dictionary<Type, IMessagePackSingleObjectSerializer> msgPackserializers = new Dictionary<Type, IMessagePackSingleObjectSerializer>();
        //private static readonly Encoding encoding = Encoding.UTF8;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            Type t = obj.GetType();
            IMessagePackSingleObjectSerializer serializer = GetSerializer(t);

            return serializer.PackSingleObject(obj);
            //using (var byteStream = new MemoryStream())
            //{
            //    serializer.Pack(byteStream, obj);
            //    return byteStream.ToArray();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            Type t = typeof(T);
            IMessagePackSingleObjectSerializer serializer = GetSerializer(t);

            return ((MessagePackSerializer<T>)serializer).UnpackSingleObject(data);
            //using (var byteStream = new MemoryStream(data))
            //{
            //    return ((MessagePackSerializer<T>)serializer).Unpack(byteStream);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] buffer, int index, int count)
        {
            Type t = typeof(T);
            IMessagePackSingleObjectSerializer serializer = GetSerializer(t);

            using (var byteStream = new MemoryStream(buffer, index, count))
            {
                return ((MessagePackSerializer<T>)serializer).Unpack(byteStream);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private IMessagePackSingleObjectSerializer GetSerializer(Type t)
        {
            IMessagePackSingleObjectSerializer serializer = null;
            if (!msgPackserializers.ContainsKey(t))
            {
                serializer = MessagePackSerializer.Get(t);
                msgPackserializers[t] = serializer;
            }
            else
            {
                serializer = msgPackserializers[t];
            }
            return serializer;
        }
    }
}
