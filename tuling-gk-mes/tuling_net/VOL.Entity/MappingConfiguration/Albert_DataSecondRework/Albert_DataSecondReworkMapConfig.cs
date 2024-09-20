using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DataSecondReworkMapConfig : EntityMappingConfiguration<Albert_DataSecondRework>
    {
        public override void Map(EntityTypeBuilder<Albert_DataSecondRework>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

