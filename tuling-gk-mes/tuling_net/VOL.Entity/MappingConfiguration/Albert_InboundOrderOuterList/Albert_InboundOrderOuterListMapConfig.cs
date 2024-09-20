using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_InboundOrderOuterListMapConfig : EntityMappingConfiguration<Albert_InboundOrderOuterList>
    {
        public override void Map(EntityTypeBuilder<Albert_InboundOrderOuterList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

