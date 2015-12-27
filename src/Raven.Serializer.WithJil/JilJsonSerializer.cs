using Jil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithJil
{
    /// <summary>
    /// 
    /// </summary>
    public class JilJsonSerializer : IDataSerializer
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            var jsonString = JSON.Serialize(obj);
            return encoding.GetBytes(jsonString);
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
            return JSON.Deserialize<T>(jsonString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] buffer, int index, int count)
        {
            var jsonString = encoding.GetString(buffer, index, count);
            return JSON.Deserialize<T>(jsonString);
        }
    }
}
