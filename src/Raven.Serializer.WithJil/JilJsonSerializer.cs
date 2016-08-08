using Jil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithJil
{
    /// <summary>
    /// 
    /// </summary>
    public class JilJsonSerializer : BasicDataSerializer, IDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public static Options Settings = Options.Utc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            byte[] res = null;
            if (TrySerialize(obj, out res))
            {
                return res;
            }

            var jsonString = JSON.Serialize(obj, Settings);
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
            object res;
            var type = typeof(T);
            if (TryDeserialize(type, data, out res))
            {
                return (T)res;
            }

            var jsonString = encoding.GetString(data);
            return JSON.Deserialize<T>(jsonString, Settings);
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
            return JSON.Deserialize(jsonString, type, Settings);
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
            return JSON.Deserialize<T>(jsonString, Settings);
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
            return JSON.Deserialize(jsonString, type, Settings);
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
