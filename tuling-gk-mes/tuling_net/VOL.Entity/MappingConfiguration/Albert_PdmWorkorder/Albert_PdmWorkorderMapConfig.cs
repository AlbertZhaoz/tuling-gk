using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_PdmWorkorderMapConfig : EntityMappingConfiguration<Albert_PdmWorkorder>
    {
        public override void Map(EntityTypeBuilder<Albert_PdmWorkorder>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

