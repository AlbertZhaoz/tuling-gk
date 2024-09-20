using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_EmEnergyRealQueryMapConfig : EntityMappingConfiguration<Albert_EmEnergyRealQuery>
    {
        public override void Map(EntityTypeBuilder<Albert_EmEnergyRealQuery>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

