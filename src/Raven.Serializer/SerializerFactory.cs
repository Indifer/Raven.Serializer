using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializerFactory
    {
        #region 字段、属性

        private static Dictionary<SerializerType, IDataSerializer> _serializerDict = new Dictionary<SerializerType, IDataSerializer>();
        private static Dictionary<SerializerType, string[]> _typeNameDict = new Dictionary<SerializerType, string[]>()
        {
            { Serializer.SerializerType.Jil ,new[] { "Raven.Serializer.WithJil","JilJsonSerializer" }},
            { Serializer.SerializerType.MsgPack , new[] {"Raven.Serializer.WithMsgPack","MsgPackSerializer" }},
            { Serializer.SerializerType.NewtonsoftBson ,new[] { "Raven.Serializer.WithNewtonsoft","NewtsBsonSerializer" }},
            { Serializer.SerializerType.NewtonsoftJson ,new[] { "Raven.Serializer.WithNewtonsoft","NewtsJsonSerializer" }},
            { Serializer.SerializerType.Protobuf , new[] {"Raven.Serializer.WithProtobuf","ProtobufSerializer" }},
            { Serializer.SerializerType.MongoDBBson ,new[] { "Raven.Serializer.WithMongoDBBson", "MongoBsonSerializer" }},
        };

        /// <summary>
        /// 缓存类型
        /// </summary>
        private static IDataSerializer GetDataSerializer(SerializerType serializerType)
        {
            if (_serializerDict.ContainsKey(serializerType))
            {
                return _serializerDict[serializerType];
            }
            else
            {
                var typeName = _typeNameDict[serializerType];
                IDataSerializer serializer = (IDataSerializer)Assembly.Load(typeName[0]).CreateInstance(string.Concat(typeName[0], ".", typeName[1]));
                if (serializer != null)
                {
                    _serializerDict[serializerType] = serializer;
                }
                return serializer;
            }
        }

        #endregion

        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="serializerType"></param>
        /// <returns></returns>
        public static IDataSerializer Create(SerializerType serializerType)
        {
            IDataSerializer serializer = GetDataSerializer(serializerType);
            //IDataSerializer serializer = (IDataSerializer)Activator.CreateInstance(type, new object[] { });
            return serializer;
        }

        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="serializerType"></param>
        /// <returns></returns>
        public static IDataSerializer Create(string serializerType)
        {
            SerializerType serializerTypeEnum;
            Enum.TryParse(serializerType, out serializerTypeEnum);
            return Create(serializerTypeEnum);
        }
    }
}
