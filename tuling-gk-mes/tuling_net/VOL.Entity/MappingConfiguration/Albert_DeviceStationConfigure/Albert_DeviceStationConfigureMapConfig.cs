using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceStationConfigureMapConfig : EntityMappingConfiguration<Albert_DeviceStationConfigure>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceStationConfigure>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

