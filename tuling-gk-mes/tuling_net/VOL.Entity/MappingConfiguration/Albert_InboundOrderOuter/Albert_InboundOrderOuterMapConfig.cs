using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_InboundOrderOuterMapConfig : EntityMappingConfiguration<Albert_InboundOrderOuter>
    {
        public override void Map(EntityTypeBuilder<Albert_InboundOrderOuter>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

