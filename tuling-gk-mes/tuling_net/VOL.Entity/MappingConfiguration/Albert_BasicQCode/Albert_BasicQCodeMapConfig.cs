using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_BasicQCodeMapConfig : EntityMappingConfiguration<Albert_BasicQCode>
    {
        public override void Map(EntityTypeBuilder<Albert_BasicQCode>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

