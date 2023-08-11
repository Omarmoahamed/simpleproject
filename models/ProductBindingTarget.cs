


using System.ComponentModel.DataAnnotations;

namespace simpleproject.models
{
    public class ProductBindingTarget
    {
        [Required]
        public string Name { get; set; } = "";
        [Range(1, 1000)]
        public decimal Price { get; set; }
        [Range(1, long.MaxValue)]
        public long categoryid { get; set; }
        [Range(1, long.MaxValue)]
        public long supplierid { get; set; }

        public product toproduct() => new product() { name = this.Name, price = this.Price,categoryid = this.categoryid, supplierid = this.supplierid };
    }
}
