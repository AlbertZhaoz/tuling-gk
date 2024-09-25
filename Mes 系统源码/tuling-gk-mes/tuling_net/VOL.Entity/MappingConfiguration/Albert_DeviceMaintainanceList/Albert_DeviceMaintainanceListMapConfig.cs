using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DeviceMaintainanceListMapConfig : EntityMappingConfiguration<Albert_DeviceMaintainanceList>
    {
        public override void Map(EntityTypeBuilder<Albert_DeviceMaintainanceList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

