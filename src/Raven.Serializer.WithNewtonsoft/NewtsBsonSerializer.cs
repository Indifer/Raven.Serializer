using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithNewtonsoft
{
    /// <summary>
    /// 
    /// </summary>
    public class NewtsBsonSerializer : IDataSerializer
    {
        private static readonly JsonSerializer serializer = new JsonSerializer() { DateFormatString = "yyyy-MM-dd HH:mm:ss" };

        /// <summary>
        /// 
        /// </summary>
        public T Deserialize<T>(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (BsonReader reader = new BsonReader(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";                    
                    T obj = serializer.Deserialize<T>(reader);
                    return obj;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BsonWriter writer = new BsonWriter(ms))
                {
                    //serializer.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    serializer.Serialize(writer, obj);
                }
                return ms.ToArray();
            }
        }
    }
}
