using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MsgPack.Serialization.CollectionSerializers;

namespace Raven.Serializer.PerformanceTest
{
    /// <summary>
    /// 商场
    /// </summary>
    public class Mall
    {
        /// <summary>
        ///自增主键
        /// </summary>
        public long ID { get; set; }


        public string Name { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// 集团商场id
        /// </summary>
        public long? GroupID { get; set; }

        public string AAAAAAAAAA { get; set; }

        public string BBBBBBBBBB { get; set; }

        public string CCCCCCCCCC { get; set; }

        public string D { get; set; }

        public string EEEEEEEEEE { get; set; }

        public string F { get; set; }

        public string G { get; set; }

        public string HHHHHHHHHH { get; set; }

        public string I { get; set; }

        public string J { get; set; }

        
        public User User { get; set; }

        /// <summary>
        /// 商场构造函数
        /// </summary>
        public Mall()
        {

        }
    }

    //[DataContract]
    public class User
    {
        //[DataMember(Order = 0)]
        public long ID { get; set; }

        //[DataMember(Order = 1)]
        public string Name { get; set; }

        //[DataMember(Order = 2)]
        public DateTime Date { get; set; }

        //[DataMember(Order = 3)]
        public long A { get; set; }

        //[DataMember(Order = 4)]
        public DateTime? Date2 { get; set; }
    }


    //[DataContract]
    public class User1
    {
        //[DataMember(Order = 0)]
        public long ID { get; set; }

        //[DataMember(Order = 1)]
        public string Name { get; set; }

        //[DataMember(Order = 2)]
        public DateTime Date { get; set; }

        //[DataMember(Order = 3)]
        //public long A { get; set; }

        //[DataMember(Order = 4)]
        public DateTime? Date2 { get; set; }
    }


    //[DataContract]
    public class User2
    {
        //[DataMember(Order = 0)]
        public long ID { get; set; }

        //[DataMember(Order = 2)]
        public DateTime Date { get; set; }
        
        //[DataMember(Order = 4)]
        public DateTime? Date2 { get; set; }

    }
}
