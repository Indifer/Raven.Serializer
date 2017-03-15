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
                using (BsonWriter writer = new BsonWriter(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";
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
            using (BsonWriter writer = new BsonWriter(stream))
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
                using (BsonReader reader = new BsonReader(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";                    
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
                using (BsonReader reader = new BsonReader(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";
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
                using (BsonReader reader = new BsonReader(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";                    
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
                using (BsonReader reader = new BsonReader(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";                    
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
            using (BsonReader reader = new BsonReader(stream))
            {
                //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";                    
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
            using (BsonReader reader = new BsonReader(stream))
            {
                //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";                    
                return Serializer.Deserialize(reader, type);
            }
        }
    }
}
