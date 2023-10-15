using Microsoft.AspNetCore.Identity;

namespace Netpobre.Models
{
    public class AppUser:IdentityUser
    {
        public string UserClient { get; set; } = default!;

    }
}
