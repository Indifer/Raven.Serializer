using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer
{
    /// <summary>
    /// 序列化类型
    /// </summary>
    public enum SerializerType
    {
        Jil = 1,
        MsgPack,
        Protobuf,
        NewtonsoftJson,
        NewtonsoftBson,
    }
}
