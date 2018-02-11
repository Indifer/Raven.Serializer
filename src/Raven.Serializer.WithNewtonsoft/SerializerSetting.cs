using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithNewtonsoft
{
    /// <summary>
    /// 
    /// </summary>
    public class SerializerSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public string DateFormatString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "DateFormatString:" + DateFormatString;
        }
    }
}
