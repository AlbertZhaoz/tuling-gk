using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceDBConfigureMapConfig : EntityMappingConfiguration<Albert_DeviceDBConfigure>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceDBConfigure>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

