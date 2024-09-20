using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceRepairMapConfig : EntityMappingConfiguration<Albert_DeviceRepair>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceRepair>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

