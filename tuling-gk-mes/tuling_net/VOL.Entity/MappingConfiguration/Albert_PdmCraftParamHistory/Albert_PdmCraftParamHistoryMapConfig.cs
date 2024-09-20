using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_PdmCraftParamHistoryMapConfig : EntityMappingConfiguration<Albert_PdmCraftParamHistory>
    {
        public override void Map(EntityTypeBuilder<Albert_PdmCraftParamHistory>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

