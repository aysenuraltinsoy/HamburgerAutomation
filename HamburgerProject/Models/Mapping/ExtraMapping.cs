using HamburgerProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerProject.Models.Mapping
{
    public class ExtraMapping : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.Property(x => x.ID).IsRequired();
            builder.Property(x => x.OrderID).IsRequired(false);
            

        }
    }
}
