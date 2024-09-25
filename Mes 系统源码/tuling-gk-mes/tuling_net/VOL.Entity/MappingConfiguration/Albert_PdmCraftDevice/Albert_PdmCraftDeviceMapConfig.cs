using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_PdmCraftDeviceMapConfig : EntityMappingConfiguration<Albert_PdmCraftDevice>
    {
        public override void Map(EntityTypeBuilder<Albert_PdmCraftDevice>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

