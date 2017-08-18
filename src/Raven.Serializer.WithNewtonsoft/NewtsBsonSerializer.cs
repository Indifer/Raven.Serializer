using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.IO;

namespace Raven.Serializer.WithNewtonsoft
{
    /// <summary>
    /// 
    /// </summary>
    public class NewtsBsonSerializer : IDataSerializer
    {
        public static readonly JsonSerializer Serializer = new JsonSerializer() { Formatting = Formatting.None };  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BsonDataWriter writer = new BsonDataWriter(ms))
                {
                    Serializer.Serialize(writer, obj);
                }
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
            using (BsonDataWriter writer = new BsonDataWriter(stream))
            {
                Serializer.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BsonDataReader reader = new BsonDataReader(ms))
                {                   
                    return Serializer.Deserialize<T>(reader);
                }
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
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BsonDataReader reader = new BsonDataReader(ms))
                {
                    return Serializer.Deserialize(reader, type);
                }
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
            using (MemoryStream ms = new MemoryStream(buffer, index, count))
            {
                using (BsonDataReader reader = new BsonDataReader(ms))
                {              
                    return Serializer.Deserialize<T>(reader);
                }
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
            using (MemoryStream ms = new MemoryStream(buffer, index, count))
            {
                using (BsonDataReader reader = new BsonDataReader(ms))
                {                 
                    return Serializer.Deserialize(reader, type);
                }
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
            using (BsonDataReader reader = new BsonDataReader(stream))
            {                    
                return Serializer.Deserialize<T>(reader);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public object Deserialize(Type type, Stream stream)
        {
            using (BsonDataReader reader = new BsonDataReader(stream))
            {
                return Serializer.Deserialize(reader, type);
            }
        }
    }
}
