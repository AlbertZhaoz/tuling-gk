using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class tbl_record_data_250MapConfig : EntityMappingConfiguration<tbl_record_data_250>
    {
        public override void Map(EntityTypeBuilder<tbl_record_data_250>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

