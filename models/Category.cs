

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace simpleproject.models
{
    public class Category
    {
        public long categoryid { get; set; }
        public string name { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public IEnumerable<product>? products { get; set; }
    }
}
