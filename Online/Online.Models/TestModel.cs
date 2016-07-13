using System;
using System.Runtime.Serialization;

namespace Online.Models {
    [DataContract]
    public class TestModel : BaseModel {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string uid { get; set; }
        [DataMember]
        public string types { get; set; }
        [DataMember]
        public string events { get; set; }
        [DataMember]
        public string more { get; set; }
        [DataMember]
        public Nullable<decimal> money { get; set; }
        [DataMember]
        public Nullable<decimal> lastmoney { get; set; }
        [DataMember]
        public Nullable<decimal> nowmoney { get; set; }
        [DataMember]
        public string bak { get; set; }
        [DataMember]
        public Nullable<System.DateTime> times { get; set; }
    }
}
