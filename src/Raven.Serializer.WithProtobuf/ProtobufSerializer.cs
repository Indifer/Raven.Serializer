using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithProtobuf
{
    /// <summary>
    /// 
    /// </summary>
    public class ProtobufSerializer : IDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public T Deserialize<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return ProtoBuf.Serializer.Deserialize<T>(ms);
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
            using (var ms = new MemoryStream(buffer, index, count))
            {
                return ProtoBuf.Serializer.Deserialize<T>(ms);
            }
        }
    }
}
