using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace iSnack.Web.API.Models
{
    public class Product
    {
        //[Required]
        [DataMember(IsRequired = true)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "名称长度不在允许范围(2-64个字符)")]
        public string Name { get; set; }

        public string Category { get; set; }

        //[JsonIgnore]
        [DataMember(IsRequired = true)]
        public decimal Price { get; set; }

        public string Remark { get; set; }
    }
}