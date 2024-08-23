using Microsoft.AspNetCore.Identity;

namespace AplicationWebUi.identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
