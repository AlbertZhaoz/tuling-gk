using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace NET_FiveMinutes_009_GraphQL.Models
{
    [Table("Tool_Lu")]
    public class Tool_Lu
    {
        [Key]
        public long ID { get; set; }

        
        [Required(AllowEmptyStrings = true)]
        [Column("标题")]
        public string? Title { get; set; }

        [GraphQLNonNullType(false)]
        [Required(AllowEmptyStrings = true)]
        [Column("标题链接")]
        public string? TitleLink { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("类别")]
        public string? Sort { get; set; }

        [Required(AllowEmptyStrings = true)]
        [Column("描述")]
        public string? Description { get; set; }
    }
}
