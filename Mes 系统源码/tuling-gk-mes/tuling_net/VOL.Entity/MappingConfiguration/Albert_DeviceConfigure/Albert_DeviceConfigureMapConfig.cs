using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceConfigureMapConfig : EntityMappingConfiguration<Albert_DeviceConfigure>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceConfigure>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

