using HamburgerProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerProject.Models.Mapping
{
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
      

        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.ID).IsRequired(true);  
         

         
        }
    }
}
