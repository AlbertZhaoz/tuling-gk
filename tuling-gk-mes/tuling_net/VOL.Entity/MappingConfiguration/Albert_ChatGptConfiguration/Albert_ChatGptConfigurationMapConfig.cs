using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_ChatGptConfigurationMapConfig : EntityMappingConfiguration<Albert_ChatGptConfiguration>
    {
        public override void Map(EntityTypeBuilder<Albert_ChatGptConfiguration>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

