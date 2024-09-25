using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Albert_BasicNumberRuleMapConfig : EntityMappingConfiguration<Albert_BasicNumberRule>
    {
        public override void Map(EntityTypeBuilder<Albert_BasicNumberRule>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

