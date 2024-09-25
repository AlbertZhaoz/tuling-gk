using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceMaintainanceMapConfig : EntityMappingConfiguration<Albert_DeviceMaintainance>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceMaintainance>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

