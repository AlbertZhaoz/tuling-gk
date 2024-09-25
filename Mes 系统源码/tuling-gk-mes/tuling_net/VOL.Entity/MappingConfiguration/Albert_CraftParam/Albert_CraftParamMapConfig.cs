using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_CraftParamMapConfig : EntityMappingConfiguration<Albert_CraftParam>
    {
        public override void Map(EntityTypeBuilder<Albert_CraftParam>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

