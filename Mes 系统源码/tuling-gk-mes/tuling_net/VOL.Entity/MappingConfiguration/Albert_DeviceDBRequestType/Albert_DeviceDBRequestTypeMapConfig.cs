using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceDBRequestTypeMapConfig : EntityMappingConfiguration<Albert_DeviceDBRequestType>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceDBRequestType>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

