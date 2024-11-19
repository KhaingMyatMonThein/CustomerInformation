using CustomerProfile.Pages;
using Microsoft.EntityFrameworkCore;

namespace CustomerProfile.Data
{
    public class CusDBContext : DbContext
    {
        public CusDBContext(DbContextOptions<CusDBContext> options) : base(options)
        {
        }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<NationalityModel> Nationalities { get; set; }

    }
}
