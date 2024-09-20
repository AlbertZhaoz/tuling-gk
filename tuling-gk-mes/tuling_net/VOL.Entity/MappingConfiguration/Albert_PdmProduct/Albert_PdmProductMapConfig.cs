using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_PdmProductMapConfig : EntityMappingConfiguration<Albert_PdmProduct>
    {
        public override void Map(EntityTypeBuilder<Albert_PdmProduct>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

