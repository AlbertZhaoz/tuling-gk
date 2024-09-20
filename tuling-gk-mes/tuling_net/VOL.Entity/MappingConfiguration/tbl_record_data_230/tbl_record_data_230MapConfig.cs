using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class tbl_record_data_230MapConfig : EntityMappingConfiguration<tbl_record_data_230>
    {
        public override void Map(EntityTypeBuilder<tbl_record_data_230>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

