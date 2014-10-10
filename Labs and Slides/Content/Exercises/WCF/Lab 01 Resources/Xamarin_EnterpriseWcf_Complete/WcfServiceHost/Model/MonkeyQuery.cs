using System;
using System.Runtime.Serialization;

namespace WcfServiceHost.Model
{
    [DataContract]
    public class MonkeyQuery
    {
        [DataMember]
        public String Family { get; set; }

        [DataMember]
        public String Subfamily { get; set; }

        [DataMember]
        public String Genus { get; set; }
    }
}
