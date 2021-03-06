﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace Raven.Serializer.WithNewtonsoft
{
    /// <summary>
    /// 
    /// </summary>
    public class NewtsJsonSerializer : BasicDataSerializer, IDataSerializer, IStringDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly JsonSerializerSettings DefalutSettings = new JsonSerializerSettings() { Formatting = Formatting.None };
        JsonSerializerSettings _setting = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private JsonSerializerSettings GetSetting()
        {
            return _setting ?? DefalutSettings;
        }

        /// <summary>
        /// 
        /// </summary>
        public NewtsJsonSerializer()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        public NewtsJsonSerializer(SerializerSetting setting)
        {
            _setting = new JsonSerializerSettings();
            _setting.DateFormatString = setting.DateFormatString;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SerializeToString(object obj)
        {
            if (obj is string) return (string)obj;
            return JsonConvert.SerializeObject(obj, GetSetting());
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            if (TrySerialize(obj, out byte[] res))
            {
                return res;
            }

            var jsonString = JsonConvert.SerializeObject(obj, GetSetting());
            return encoding.GetBytes(jsonString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public void Serialize(object obj, Stream stream)
        {
            byte[] res = Serialize(obj);
            stream.Write(res, 0, res.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            var type = typeof(T);
            if (TryDeserialize(type, data, out object res))
            {
                return (T)res;
            }

            var jsonString = encoding.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonString, GetSetting());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] data)
        {
            if (TryDeserialize(type, data, out object res))
            {
                return res;
            }
            var jsonString = encoding.GetString(data);
            return JsonConvert.DeserializeObject(jsonString, type, GetSetting());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data, int index, int count)
        {
            var type = typeof(T);
            if (TryDeserialize(type, data, index, count, out object res))
            {
                return (T)res;
            }

            var jsonString = encoding.GetString(data, index, count);
            return JsonConvert.DeserializeObject<T>(jsonString, GetSetting());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] data, int index, int count)
        {
            if (TryDeserialize(type, data, index, count, out object res))
            {
                return res;
            }

            var jsonString = encoding.GetString(data, index, count);
            return JsonConvert.DeserializeObject(jsonString, type, GetSetting());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public T Deserialize<T>(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);

            return Deserialize<T>(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public object Deserialize(Type type, Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return Deserialize(type, bytes);
        }
    }
}
