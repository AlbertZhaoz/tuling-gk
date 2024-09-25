using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class albert_deviceplusMapConfig : EntityMappingConfiguration<albert_deviceplus>
    {
        public override void Map(EntityTypeBuilder<albert_deviceplus>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

