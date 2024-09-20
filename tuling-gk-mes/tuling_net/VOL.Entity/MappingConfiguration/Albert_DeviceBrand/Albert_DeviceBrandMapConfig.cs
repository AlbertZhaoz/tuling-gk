using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceBrandMapConfig : EntityMappingConfiguration<Albert_DeviceBrand>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceBrand>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

