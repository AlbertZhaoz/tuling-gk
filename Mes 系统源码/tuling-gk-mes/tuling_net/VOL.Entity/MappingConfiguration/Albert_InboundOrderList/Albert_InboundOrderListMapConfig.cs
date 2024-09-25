using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_InboundOrderListMapConfig : EntityMappingConfiguration<Albert_InboundOrderList>
    {
        public override void Map(EntityTypeBuilder<Albert_InboundOrderList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

