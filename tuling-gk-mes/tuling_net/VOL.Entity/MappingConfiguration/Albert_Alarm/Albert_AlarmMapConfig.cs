using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_AlarmMapConfig : EntityMappingConfiguration<Albert_Alarm>
    {
        public override void Map(EntityTypeBuilder<Albert_Alarm>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

