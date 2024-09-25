using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_ChatGptHistoryRecordMapConfig : EntityMappingConfiguration<Albert_ChatGptHistoryRecord>
    {
        public override void Map(EntityTypeBuilder<Albert_ChatGptHistoryRecord>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

