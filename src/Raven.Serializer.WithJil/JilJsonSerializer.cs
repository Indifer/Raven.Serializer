using Jil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithJil
{
    public class JilJsonSerializer : IDataSerializer
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        
        public byte[] Serialize(object obj)
        {
            var jsonString = JSON.Serialize(obj);
            return encoding.GetBytes(jsonString);
        }

        public T Deserialize<T>(byte[] data)
        {
            var jsonString = encoding.GetString(data);
            return JSON.Deserialize<T>(jsonString);
        }
    }
}
