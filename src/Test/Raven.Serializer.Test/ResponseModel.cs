using System.Runtime.Serialization;

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
