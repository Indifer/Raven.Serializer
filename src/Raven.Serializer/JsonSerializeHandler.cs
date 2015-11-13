using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Client.Helper.DataConvertHandler
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonSerializeHandler : IDataSerializeHandler
    {
        private IsoDateTimeConverter timeConverter;

        /// <summary>
        /// 构造函数
        /// </summary>
        public JsonSerializeHandler()
        {
            timeConverter = new IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(object obj)
        {
            string strData = JsonConvert.SerializeObject(obj, timeConverter);
            return Encoding.UTF8.GetBytes(strData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            string strObj = UTF8Encoding.UTF8.GetString(data);
            T obj = JsonConvert.DeserializeObject<T>(strObj);
            return obj;
        }
    }
}
