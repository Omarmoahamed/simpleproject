

using System.Text.Json.Serialization;
namespace simpleproject.models
{
    public class supplier
    {
        public long supplierid { get; set; }

        public string name { get; set; } = string.Empty;

        public string city { get; set; } = string.Empty;

        [JsonIgnore(Condition =JsonIgnoreCondition.Always)]
        public IEnumerable<product>? products { get; set; }
    }
}
