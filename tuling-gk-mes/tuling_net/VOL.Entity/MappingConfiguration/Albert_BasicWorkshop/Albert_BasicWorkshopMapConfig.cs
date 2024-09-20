using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_BasicWorkshopMapConfig : EntityMappingConfiguration<Albert_BasicWorkshop>
    {
        public override void Map(EntityTypeBuilder<Albert_BasicWorkshop>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

