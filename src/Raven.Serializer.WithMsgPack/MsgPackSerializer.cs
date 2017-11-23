
using MessagePack;
using System;
using System.IO;

namespace Raven.Serializer.WithMsgPack
{
    /// <summary>
    /// 
    /// </summary>
    public class MsgPackSerializer : IDataSerializer
    {
        //private static Dictionary<string, IMessagePackSingleObjectSerializer> msgPackserializers = new Dictionary<string, IMessagePackSingleObjectSerializer>();
        //private static object _obj = new object();
        //private static readonly Encoding encoding = Encoding.UTF8;
        //private SerializationContext _context;

        /// <summary>
        /// 
        /// </summary>
        public MsgPackSerializer()
        {
            //_context = new SerializationContext() { SerializationMethod = SerializationMethod.Map };
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="serializationMethod"></param>
        //public MsgPackSerializer(int serializationMethod)
        //{
        //    //_context = new SerializationContext() { SerializationMethod = (SerializationMethod)serializationMethod };
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            //Type t = obj.GetType();
            //MessagePackSerializer serializer = GetSerializer(t);

            //return serializer.PackSingleObject(obj);

            return MessagePackSerializer.NonGeneric.Serialize(obj.GetType(), obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public void Serialize(object obj, Stream stream)
        {
            //Type t = obj.GetType();
            //MessagePackSerializer serializer = GetSerializer(t);

            //serializer.Pack(stream, obj);

            MessagePackSerializer.NonGeneric.Serialize(obj.GetType(), stream, obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            //MessagePackSerializer serializer = GetSerializer<T>();

            //return (T)serializer.UnpackSingleObject(data);

            return MessagePackSerializer.Deserialize<T>(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] data)
        {
            //MessagePackSerializer serializer = GetSerializer(type);
            //return serializer.UnpackSingleObject(data);

            return MessagePackSerializer.NonGeneric.Deserialize(type, data);
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
            //Type t = typeof(T);
            //MessagePackSerializer serializer = GetSerializer<T>();

            //using (var byteStream = new MemoryStream(buffer, index, count))
            //{
            //    return (T)serializer.Unpack(byteStream);
            //}

            ArraySegment<byte> bytes = new ArraySegment<byte>(buffer, index, count);
            return MessagePackSerializer.Deserialize<T>(bytes);

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
            //MessagePackSerializer serializer = GetSerializer(type);

            //using (var byteStream = new MemoryStream(buffer, index, count))
            //{
            //    return serializer.Unpack(byteStream);
            //}

            ArraySegment<byte> bytes = new ArraySegment<byte>(buffer, index, count);
            return MessagePackSerializer.NonGeneric.Deserialize(type, bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserialize<T>(Stream stream)
        {
            //Type t = typeof(T);
            //MessagePackSerializer serializer = GetSerializer<T>();
            //return (T)serializer.Unpack(stream);

            return MessagePackSerializer.Deserialize<T>(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public object Deserialize(Type type, Stream stream)
        {
            //MessagePackSerializer serializer = GetSerializer(type);
            //return serializer.Unpack(stream);

            return MessagePackSerializer.NonGeneric.Deserialize(type, stream);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //private MessagePackSerializer GetSerializer(Type t)
        //{
        //    return MessagePackSerializer.Get(t, _context);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="t"></param>
        ///// <returns></returns>
        //private MessagePackSerializer GetSerializer<T>()
        //{
        //    MessagePack.MessagePackSerializer.Serialize
        //    return MessagePackSerializer.Get<T>(_context);
        //}

    }
}
