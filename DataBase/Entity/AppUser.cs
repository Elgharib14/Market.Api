using Microsoft.AspNetCore.Identity;

namespace Backery.DataBase.Entity
{
    public class AppUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
