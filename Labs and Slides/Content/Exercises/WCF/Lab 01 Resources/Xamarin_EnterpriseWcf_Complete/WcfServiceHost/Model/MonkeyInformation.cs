using System;
using System.Runtime.Serialization;

namespace WcfServiceHost.Model
{
    [DataContract]
    public class MonkeyInformation
    {
        [DataMember]
        public String Family { get; set; }

        [DataMember]
        public String Subfamily { get; set; }

        [DataMember]
        public String Genus { get; set; }

        [DataMember]
        public String ScientificName { get; set; }

        [DataMember]
        public String CommonName { get; set; }
    }
}
