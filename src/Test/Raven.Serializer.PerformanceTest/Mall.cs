using System;
using System.Runtime.Serialization;

namespace Raven.Serializer.PerformanceTest
{
    /// <summary>
    /// 商场
    /// </summary>
    //[MessagePack.MessagePackObject]
    [DataContract]
    public class Mall
    {
        /// <summary>
        ///自增主键
        /// </summary>
        [DataMember(Order = 0)]
        public long ID { get; set; }


        [DataMember(Order = 1, Name = "n")]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public DateTime Date { get; set; }

        /// <summary>
        /// 集团商场id
        /// </summary>
        [DataMember(Order = 3)]
        public long? GroupID { get; set; }

        [DataMember(Order = 4)]
        public string AAAAAAAAAA { get; set; }

        [DataMember(Order = 5)]
        public string BBBBBBBBBB { get; set; }

        [DataMember(Order = 6)]
        public string CCCCCCCCCC { get; set; }

        [DataMember(Order = 7)]
        public string D { get; set; }

        [DataMember(Order = 8)]
        public string EEEEEEEEEE { get; set; }

        [DataMember(Order = 9)]
        public string F { get; set; }

        [DataMember(Order = 10)]
        public string G { get; set; }

        [DataMember(Order = 11)]
        public string HHHHHHHHHH { get; set; }

        [DataMember(Order = 13)]
        public string I { get; set; }

        [DataMember(Order = 14)]
        public string J { get; set; }
        
        [DataMember(Order = 15)]
        public User User { get; set; }

        /// <summary>
        /// 商场构造函数
        /// </summary>
        public Mall()
        {

        }
    }

    [DataContract]
    public class Mall2
    {
        [DataMember(Order = 1)]
        public string n { get; set; }

    }

    [DataContract]
    //[MessagePack.MessagePackObject]
    public class User
    {
        [DataMember(Order = 0)]
        public long ID { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public DateTime Date { get; set; }

        [DataMember(Order = 3)]
        public long A { get; set; }

        [DataMember(Order = 4)]
        public DateTime? Date2 { get; set; }
    }


    [DataContract]
    //[MessagePack.MessagePackObject]
    public class User1
    {
        [DataMember(Order = 0)]
        public long ID { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public DateTime Date { get; set; }

        //[DataMember(Order = 3)]
        //public long A { get; set; }

        [DataMember(Order = 4)]
        public DateTime? Date2 { get; set; }
    }


    [DataContract]
    //[MessagePack.MessagePackObject]
    public class User2
    {
        public override string ToString()
        {
            return base.ToString();
        }

        [DataMember(Order = 0)]
        public long ID { get; set; }

        [DataMember(Order = 2)]
        public DateTime Date { get; set; }
        
        [DataMember(Order = 4)]
        public DateTime? Date2 { get; set; }

    }
}
