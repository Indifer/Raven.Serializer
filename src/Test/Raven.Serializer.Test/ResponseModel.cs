using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Serializer.Test
{

    [DataContract]
    public class ResponseModel
    {
        [DataMember]
        public string ID { get; set; }
        public string Name { get; set; }
    }

    [DataContract]
    public class ResponseModel_2 : ResponseModel
    {
        [DataMember]
        public string Date { get; set; }
    }

}
