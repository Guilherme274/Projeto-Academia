using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Infraestructure.Data.Security
{
    public class SecurityContext : IdentityDbContext<User>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
            
        }
    }
}