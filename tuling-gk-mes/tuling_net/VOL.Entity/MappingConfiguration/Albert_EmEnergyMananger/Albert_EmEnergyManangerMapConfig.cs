using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_EmEnergyManangerMapConfig : EntityMappingConfiguration<Albert_EmEnergyMananger>
    {
        public override void Map(EntityTypeBuilder<Albert_EmEnergyMananger>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

