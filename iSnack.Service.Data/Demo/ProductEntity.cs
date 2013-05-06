using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace iSnack.Service.Data.Demo
{
    [DataContract]
    public class ProductEntity : iSnackEntity
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember(IsRequired = true)]
        public decimal Price { get; set; }

        //[IgnoreDataMember]
        [DataMember(IsRequired = false)]
        public string Remark { get; set; }
    }
}
