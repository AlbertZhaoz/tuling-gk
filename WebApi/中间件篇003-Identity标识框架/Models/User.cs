using Microsoft.AspNetCore.Identity;

namespace NET_FiveMinutes_008_UseIdentity.Models
{
    public class User:IdentityUser<long>
    {
        public DateTime CreateTime { get; set; }
        public string? NickName { get; set; }
    }
}
