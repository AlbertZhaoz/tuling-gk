using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceTypeMapConfig : EntityMappingConfiguration<Albert_DeviceType>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceType>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

