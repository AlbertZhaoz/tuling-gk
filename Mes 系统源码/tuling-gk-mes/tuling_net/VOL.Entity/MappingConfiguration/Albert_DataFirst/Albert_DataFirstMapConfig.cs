using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DataFirstMapConfig : EntityMappingConfiguration<Albert_DataFirst>
    {
        public override void Map(EntityTypeBuilder<Albert_DataFirst>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

