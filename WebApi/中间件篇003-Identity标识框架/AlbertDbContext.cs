using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NET_FiveMinutes_008_UseIdentity.Models;

namespace NET_FiveMinutes_008_UseIdentity
{
    public class AlbertDbContext:IdentityDbContext<User,Role,long>
    {
        public AlbertDbContext(DbContextOptions<AlbertDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
