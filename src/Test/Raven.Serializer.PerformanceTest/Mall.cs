using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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

        /// <summary>
        /// 集团商场id
        /// </summary>
        public long? GroupID { get; set; }

        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public string D { get; set; }

        public string E { get; set; }

        public string F { get; set; }

        public string G { get; set; }

        public string H { get; set; }

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

    public class User
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }

}
