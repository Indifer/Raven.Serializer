using System;
using System.Text;

namespace Raven.Serializer
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BasicDataSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        protected static readonly Encoding encoding = Encoding.UTF8;
        
        /// <summary>
        /// 
        /// </summary>
        protected static readonly Type stringType = typeof(string);
        
        /// <summary>
        /// 
        /// </summary>
        protected static readonly Type byteArrayType = typeof(byte[]);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] SerializeString(string obj)
        {
            return encoding.GetBytes(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool TrySerialize(object obj, out byte[] res)
        {
            if (obj is byte[])
            {
                res = obj as byte[];
                return true;
            }
            else if (obj is string)
            {
                res = SerializeString((string)obj);
                return true;
            }

            res = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool TryDeserialize(Type type, byte[] data, out object res)
        {
            return this.TryDeserialize(type, data, 0, data.Length, out res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public bool TryDeserialize(Type type, byte[] data, int index, int count, out object res)
        {
            if (type == byteArrayType)
            {
                res = data;
                return true;
            }
            else if (type == stringType)
            {
                res = encoding.GetString(data, index, count);
                return true;
            }

            res = null;
            return false;
        }
    }
}
