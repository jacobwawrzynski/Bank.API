using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class User : IdentityUser
    {
        public string Address { get; set; }
        public ICollection<Account>? Accounts { get; set; }
    }
}
