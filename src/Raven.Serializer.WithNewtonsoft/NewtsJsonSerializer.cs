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
    public class NewtsJsonSerializer : BasicDataSerializer, IDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public static JsonSerializerSettings Settings = new JsonSerializerSettings() { Formatting = Formatting.None };

        JsonSerializerSettings _setting = null;

        JsonSerializerSettings GetSetting()
        {
            return _setting ?? Settings;
        }

        public NewtsJsonSerializer() { }
        public NewtsJsonSerializer(SerizlizerSetting setting)
        {
            _setting = new JsonSerializerSettings();
            _setting.DateFormatString = setting.DateFormatString;
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Serialize(object obj)
        {
            byte[] res = null;
            if (TrySerialize(obj, out res))
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
            object res;
            var type = typeof(T);
            if (TryDeserialize(type, data, out res))
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
            object res;
            if (TryDeserialize(type, data, out res))
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
            object res;
            var type = typeof(T);
            if (TryDeserialize(type, data, index, count, out res))
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
            object res;
            if (TryDeserialize(type, data, index, count, out res))
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
