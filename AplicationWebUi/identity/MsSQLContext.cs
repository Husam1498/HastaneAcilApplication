using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AplicationWebUi.identity
{
    public class MsSQLContext:IdentityDbContext<User>
    {
        public MsSQLContext(DbContextOptions<MsSQLContext> options):base(options)
        {
            
        }

    }
}
