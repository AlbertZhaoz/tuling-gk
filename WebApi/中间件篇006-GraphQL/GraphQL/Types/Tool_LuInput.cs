using HotChocolate;

namespace NET_FiveMinutes_009_GraphQL.GraphQL.Types
{
    public class Tool_LuInput
    {
        public long? ID { get; set; }

        [GraphQLNonNullType]
        public string Title { get; set; }

        public string? TitleLink { get; set; }

        public string? Sort { get; set; }

        public string? Description { get; set; }
    }
}
