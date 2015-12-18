using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithNewtonsoft
{
    /// <summary>
    /// 
    /// </summary>
    public class NewtsJsonSerializer : IDataSerializer
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// 
        /// </summary>
        public T Deserialize<T>(byte[] data)
        {
            var jsonString = encoding.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            return encoding.GetBytes(jsonString);
        }
    }
}
