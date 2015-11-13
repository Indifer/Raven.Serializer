using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer
{
    public interface IDataSerializer
    {
        byte[] Serialize(object obj);

		Task<byte[]> SerializeAsync(object obj);

        T Deserialize<T>(byte[] data);

		Task<object> DeserializeAsync(byte[] data);
    }

    
}
