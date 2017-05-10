using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.WithNewtonsoft
{
    public class SerizlizerSetting
    {
        public string DateFormatString { get; set; }

        public override string ToString()
        {
            return "DateFormatString:" + DateFormatString;
        }
    }
}
