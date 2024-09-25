using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceDataTypeMapConfig : EntityMappingConfiguration<Albert_DeviceDataType>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceDataType>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

