

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace simpleproject.models

{
    public class product
    {
        public long productid { get; set; }

        public string name { get; set; } = string.Empty;

        
        [Column(TypeName ="decimal(8,2)")]
        public decimal price { get; set; }
        
        public enum productquality 
        {
            high =1, 
            low =2
        }
        public long categoryid { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public Category? category { get; set; }

       
        public productquality quality { get; set; }
        public long supplierid { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public supplier? supplier { get; set; }



    }
}
