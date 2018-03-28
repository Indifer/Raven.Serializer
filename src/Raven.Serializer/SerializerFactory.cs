using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Raven.Serializer
{
    /// <summary>
    /// 
    /// </summary>
    public static class SerializerFactory
    {
        #region 字段、属性

        private static readonly Dictionary<string, IDataSerializer> _serializerDict = new Dictionary<string, IDataSerializer>();
        private static readonly Dictionary<SerializerType, string[]> _typeNameDict = new Dictionary<SerializerType, string[]>()
        {
            { Serializer.SerializerType.Jil ,new[] { "Raven.Serializer.WithJil","JilJsonSerializer" }},
            { Serializer.SerializerType.MsgPackCli , new[] { "Raven.Serializer.WithMsgPackCli", "MsgPackCliSerializer" }},
            { Serializer.SerializerType.NewtonsoftBson ,new[] { "Raven.Serializer.WithNewtonsoft","NewtsBsonSerializer" }},
            { Serializer.SerializerType.NewtonsoftJson ,new[] { "Raven.Serializer.WithNewtonsoft","NewtsJsonSerializer" }},
            { Serializer.SerializerType.Protobuf , new[] { "Raven.Serializer.WithProtobuf", "ProtobufSerializer" }},
            { Serializer.SerializerType.MessagePack , new[] { "Raven.Serializer.WithMessagePack", "MessagePackSerializer" }},
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
                if (type == null)
                {
                    throw new Exception($"缺少程序集:{typeName[0]}");
                }
                IDataSerializer serializer = Activator.CreateInstance(type, args) as IDataSerializer;
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
            return $"{_typeNameDict[serializerType][1]}:{(args == null ? string.Empty : string.Join("_", args))}";
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
        /// <param name="args"></param>
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
        /// <param name="serializerTypeStr"></param>
        /// <returns></returns>
        public static IDataSerializer Create(string serializerTypeStr)
        {
            return Create(serializerTypeStr, null);
        }

        /// <summary>
        /// 创建类型
        /// </summary>
        /// <param name="serializerTypeStr"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IDataSerializer Create(string serializerTypeStr, object[] args)
        {
            SerializerType serializerType;
            Enum.TryParse(serializerTypeStr, out serializerType);
            return Create(serializerType, args);
        }
    }
}
