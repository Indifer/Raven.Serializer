namespace Raven.Serializer
{
    /// <summary>
    /// 序列化类型
    /// </summary>
    public enum SerializerType
    {
        /// <summary>
        /// 
        /// </summary>
        Jil = 1,
        /// <summary>
        /// 
        /// </summary>
        MsgPack = 2,
        /// <summary>
        /// 
        /// </summary>
        Protobuf = 3,
        /// <summary>
        /// 
        /// </summary>
        NewtonsoftJson = 4,
        /// <summary>
        /// 
        /// </summary>
        NewtonsoftBson = 5,

        /// <summary>
        /// 
        /// </summary>
        //MongoDBJson = 6,

#if net45 || net46
        /// <summary>
        /// 
        /// </summary>
        MongoDBBson = 7,
#endif
    }
}
