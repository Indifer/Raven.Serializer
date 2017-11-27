using System;
using System.IO;

namespace Raven.Serializer.WithProtobuf
{
    public class ProtobufSerializer : IDataSerializer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.NonGeneric.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public void Serialize(object obj, Stream stream)
        {
            ProtoBuf.Serializer.NonGeneric.Serialize(stream, obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            using (var byteStream = new MemoryStream(data))
            {
                return ProtoBuf.Serializer.Deserialize<T>(byteStream);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] data)
        {
            using (var byteStream = new MemoryStream(data))
            {
                return ProtoBuf.Serializer.NonGeneric.Deserialize(type, byteStream);
            }
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
            using (var byteStream = new MemoryStream(buffer, index, count))
            {
                return ProtoBuf.Serializer.Deserialize<T>(byteStream);
            }
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
            using (var byteStream = new MemoryStream(buffer, index, count))
            {
                return ProtoBuf.Serializer.NonGeneric.Deserialize(type, byteStream);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserialize<T>(Stream stream)
        {
            return ProtoBuf.Serializer.Deserialize<T>(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public object Deserialize(Type type, Stream stream)
        {
            return ProtoBuf.Serializer.NonGeneric.Deserialize(type, stream);
        }
    }
}
