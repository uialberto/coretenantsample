using Microsoft.EntityFrameworkCore;

namespace AppWeb.DataAccess.Context
{
    //https://dev.to/isaacojeda/asp-net-core-6-multi-tenant-multi-database-parte-3-2onc
    public class TenantAdminDbContext : DbContext
    {
        public TenantAdminDbContext(DbContextOptions<TenantAdminDbContext> options)
            : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
