using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.Newtonsoft
{
    public class NewtsJsonSerializer : IDataSerializer
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public T Deserialize<T>(byte[] data)
        {
            var jsonString = encoding.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public byte[] Serialize(object obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            return encoding.GetBytes(jsonString);
        }
    }
}
