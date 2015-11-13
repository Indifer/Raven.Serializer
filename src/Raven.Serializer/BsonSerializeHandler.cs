using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Client.Helper.DataConvertHandler
{
    /// <summary>
    /// 
    /// </summary>
    public class BsonSerializeHandler : IDataSerializeHandler
    {
        /// <summary>
        /// 序列化成Bson
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BsonWriter writer = new BsonWriter(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serializer.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                    serializer.Serialize(writer, obj);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 从Bson反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bsonData"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] bsonData)
        {
            using (MemoryStream ms = new MemoryStream(bsonData))
            {
                using (BsonReader reader = new BsonReader(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serializer.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                    T obj = serializer.Deserialize<T>(reader);
                    return obj;
                }
            }
        }
    }
}
