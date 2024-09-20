using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_DataSecondMapConfig : EntityMappingConfiguration<Albert_DataSecond>
    {
        public override void Map(EntityTypeBuilder<Albert_DataSecond>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

