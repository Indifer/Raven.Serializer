﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace Raven.Serializer.WithNewtonsoft
{
    /// <summary>
    /// 
    /// </summary>
    public class NewtsJsonSerializer : BasicDataSerializer, IDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public static JsonSerializerSettings Settings = new JsonSerializerSettings() { Formatting = Formatting.None };

        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            if (TrySerialize(obj, out byte[] res))
            {
                return res;
            }

            var jsonString = JsonConvert.SerializeObject(obj, Settings);
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
            return JsonConvert.DeserializeObject<T>(jsonString, Settings);
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
            return JsonConvert.DeserializeObject(jsonString, type, Settings);
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
            return JsonConvert.DeserializeObject<T>(jsonString, Settings);
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
            return JsonConvert.DeserializeObject(jsonString, type, Settings);
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
