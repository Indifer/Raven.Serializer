using System;
using System.Collections.Generic;
using System.Reflection;

namespace Raven.Serializer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializerFactory
    {
        #region 字段、属性

        private static Dictionary<string, IDataSerializer> _serializerDict = new Dictionary<string, IDataSerializer>();
        private static Dictionary<SerializerType, string[]> _typeNameDict = new Dictionary<SerializerType, string[]>()
        {
            { Serializer.SerializerType.Jil ,new[] { "Raven.Serializer.WithJil","JilJsonSerializer" }},
            { Serializer.SerializerType.MsgPack , new[] {"Raven.Serializer.WithMsgPack","MsgPackSerializer" }},
            { Serializer.SerializerType.NewtonsoftBson ,new[] { "Raven.Serializer.WithNewtonsoft","NewtsBsonSerializer" }},
            { Serializer.SerializerType.NewtonsoftJson ,new[] { "Raven.Serializer.WithNewtonsoft","NewtsJsonSerializer" }},
            { Serializer.SerializerType.Protobuf , new[] {"Raven.Serializer.WithProtobuf","ProtobufSerializer" }},
#if net45 || net46
            { Serializer.SerializerType.MongoDBBson ,new[] { "Raven.Serializer.WithMongoDBBson", "MongoBsonSerializer" }},
#endif
        };

        /// <summary>
        /// 缓存类型
        /// </summary>
        private static IDataSerializer GetDataSerializer(SerializerType serializerType, object[] args = null)
        {
            string key = GetKey(serializerType, args);
            if (_serializerDict.ContainsKey(key))
            {
                return _serializerDict[key];
            }
            else
            {
                var typeName = _typeNameDict[serializerType];
                Type type = Assembly.Load(new AssemblyName(typeName[0])).GetType(string.Concat(typeName[0], ".", typeName[1]), false, true);
                IDataSerializer serializer = (IDataSerializer)Activator.CreateInstance(type, args);
                //IDataSerializer serializer = (IDataSerializer)Assembly.Load(new AssemblyName(typeName[0])).CreateInstance(string.Concat(typeName[0], ".", typeName[1]), true, BindingFlags.Default, null, args, null, null);
                if (serializer != null)
                {
                    _serializerDict[key] = serializer;
                }
                return serializer;
            }
        }

#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializerType"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static string GetKey(SerializerType serializerType, object[] args = null)
        {
            return string.Format("{0}:{1}", _typeNameDict[serializerType][1], args == null ? string.Empty : string.Join("_", args));
        }

        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="serializerType"></param>
        /// <returns></returns>
        public static IDataSerializer Create(SerializerType serializerType)
        {
            return Create(serializerType, null);
        }

        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="serializerType"></param>
        /// <returns></returns>
        public static IDataSerializer Create(SerializerType serializerType, object[] args)
        {
            IDataSerializer serializer = GetDataSerializer(serializerType, args);
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
            return Create(serializerType, null);
        }

        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="serializerType"></param>
        /// <returns></returns>
        public static IDataSerializer Create(string serializerType, object[] args)
        {
            SerializerType serializerTypeEnum;
            Enum.TryParse(serializerType, out serializerTypeEnum);
            return Create(serializerTypeEnum, args);
        }
    }
}
