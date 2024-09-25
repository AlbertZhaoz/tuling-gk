using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_EmEnergyQueryMapConfig : EntityMappingConfiguration<Albert_EmEnergyQuery>
    {
        public override void Map(EntityTypeBuilder<Albert_EmEnergyQuery>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

