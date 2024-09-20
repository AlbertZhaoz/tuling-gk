using Microsoft.EntityFrameworkCore;
using NET_FiveMinutes_009_GraphQL.Models;

namespace NET_FiveMinutes_009_GraphQL.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Tool_Lu> Tool_Lu { get; set; }

        public AppDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
