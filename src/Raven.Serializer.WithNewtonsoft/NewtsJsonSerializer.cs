using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static JsonSerializerSettings settings = new JsonSerializerSettings();

        public NewtsJsonSerializer()
        {
            //settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            settings.Formatting = Formatting.None;
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj, settings);
            return encoding.GetBytes(jsonString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="stream"></param>
        public void Serialize(object obj, Stream stream)
        {
            var data = Serialize(obj);
            stream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            var jsonString = encoding.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] data)
        {
            var jsonString = encoding.GetString(data);
            return JsonConvert.DeserializeObject(jsonString, type, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] buffer, int index, int count)
        {
            var jsonString = encoding.GetString(buffer, index, count);
            return JsonConvert.DeserializeObject<T>(jsonString, settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public object Deserialize(Type type, byte[] buffer, int index, int count)
        {
            var jsonString = encoding.GetString(buffer, index, count);
            return JsonConvert.DeserializeObject(jsonString, type, settings);
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
