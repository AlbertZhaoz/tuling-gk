using HotChocolate;
using NET_FiveMinutes_009_GraphQL.Data;
using NET_FiveMinutes_009_GraphQL.Models;

namespace NET_FiveMinutes_009_GraphQL.GraphQL.Query
{
    // 基于约定
    [GraphQLDescription("Represents the queries available.")]
    public class QueryToolLus
    {
        // 此处加[Service]表示上下文来自于HotChocolate框架中
        [GraphQLDescription("Gets the queryable tool-lus list.")]
        public IQueryable<Tool_Lu> GetToolLusList([Service] AppDbContext context)
        {
            return context.Tool_Lu;
        }

        // 此处加[Service]表示上下文来自于HotChocolate框架中
        // 获取单个ToolLus
        [GraphQLDescription("Gets the queryable single tool-lus.")]
        public Tool_Lu GetToolLus(long id,[Service] AppDbContext context)
        {
            return context.Tool_Lu.First(a=>a.ID == id);
        }
    }
}
