using HotChocolate;
using HotChocolate.Types.Relay;
using NET_FiveMinutes_009_GraphQL.Data;
using NET_FiveMinutes_009_GraphQL.GraphQL.Types;
using NET_FiveMinutes_009_GraphQL.Models;

namespace NET_FiveMinutes_009_GraphQL.GraphQL.Mutation
{
    [GraphQLDescription("Represents the mutations available.")]
    public class MutationToolLus
    {
        [GraphQLDescription("Add a tool_lu")]
        public async Task<Tool_Lu?> AddToolLu(Tool_LuInput? toolLu,[Service] AppDbContext context)
        {
            var tool = new Tool_Lu()
            {
                Title = toolLu.Title,
                TitleLink = toolLu.TitleLink,
                Description = toolLu.Description,
                Sort = toolLu.Sort
            };
            context.Tool_Lu.Add(tool);
            await context.SaveChangesAsync();

            return context.Tool_Lu.First(a=>a.Title == tool.Title
                                            &&a.TitleLink == tool.TitleLink
                                            &&a.Description == tool.Description
                                            &&a.Sort == tool.Sort);
        }

        [GraphQLDescription("Update a tool_lu")]
        public async Task<Tool_Lu?> UpdateTitleAsync([ID] long id, string title,[Service] AppDbContext context)
        {
            var tool = context.Tool_Lu.First(a=>a.ID == id);
            tool.Title = title;
            context.Tool_Lu.Update(tool);
            await context.SaveChangesAsync();
            return tool;
        }

        [GraphQLDescription("Delete a tool_lu")]
        public async Task<Tool_Lu?> DeleteTitleAsync([ID] long id,[Service] AppDbContext context)
        {
            var tool = context.Tool_Lu.First(a=>a.ID == id);
            context.Tool_Lu.Remove(tool);
            await context.SaveChangesAsync();
            return tool;
        }
    }
}
