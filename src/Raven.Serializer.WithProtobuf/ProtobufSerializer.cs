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
        public byte[] Serialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
