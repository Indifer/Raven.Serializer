
using MessagePack;
using System;
using System.IO;

namespace Raven.Serializer.WithMessagePack
{
    /// <summary>
    /// 
    /// </summary>
    public class MessagePackSerializer : IDataSerializer
    {        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            return MessagePack.MessagePackSerializer.NonGeneric.Serialize(obj.GetType(), obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public void Serialize(object obj, Stream stream)
        {
            MessagePack.MessagePackSerializer.NonGeneric.Serialize(obj.GetType(), stream, obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            return MessagePack.MessagePackSerializer.Deserialize<T>(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] data)
        {
            return MessagePack.MessagePackSerializer.NonGeneric.Deserialize(type, data);
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
            ArraySegment<byte> bytes = new ArraySegment<byte>(buffer, index, count);
            return MessagePack.MessagePackSerializer.Deserialize<T>(bytes);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] buffer, int index, int count)
        {
            ArraySegment<byte> bytes = new ArraySegment<byte>(buffer, index, count);
            return MessagePack.MessagePackSerializer.NonGeneric.Deserialize(type, bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserialize<T>(Stream stream)
        {
            return MessagePack.MessagePackSerializer.Deserialize<T>(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public object Deserialize(Type type, Stream stream)
        {
            return MessagePack.MessagePackSerializer.NonGeneric.Deserialize(type, stream);
        }        

    }
}
