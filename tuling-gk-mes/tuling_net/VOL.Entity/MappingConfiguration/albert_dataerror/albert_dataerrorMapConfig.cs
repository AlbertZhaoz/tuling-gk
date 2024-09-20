using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class albert_dataerrorMapConfig : EntityMappingConfiguration<albert_dataerror>
    {
        public override void Map(EntityTypeBuilder<albert_dataerror>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

