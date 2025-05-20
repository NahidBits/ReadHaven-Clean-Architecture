using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadHaven.Identity.Models;

namespace ReadHaven.Identity;

public class ReadHavenIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public ReadHavenIdentityDbContext()
    {

    }

    public ReadHavenIdentityDbContext(DbContextOptions<ReadHavenIdentityDbContext> options) : base(options)
    {
    }
}
