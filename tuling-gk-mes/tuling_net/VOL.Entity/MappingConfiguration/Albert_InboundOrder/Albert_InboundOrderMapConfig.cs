using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_InboundOrderMapConfig : EntityMappingConfiguration<Albert_InboundOrder>
    {
        public override void Map(EntityTypeBuilder<Albert_InboundOrder>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

