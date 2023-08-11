
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace simpleproject.models
{
    public class reviewmap
    {
        public reviewmap(EntityTypeBuilder<review> entityBuilder) 
        {
            entityBuilder.HasKey(r => r.reviewid);
        }
    }
}
