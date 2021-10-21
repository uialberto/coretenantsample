using AppWeb.Entities;
using AppWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppWeb.DataAccess.Context
{
    public class SingleTenantDbContext : DbContext
    {
        private readonly TenantDto _tenant;

        public SingleTenantDbContext(
            DbContextOptions<SingleTenantDbContext> options,
            ITenantAccessor<TenantDto> tenantAccessor) : base(options)
        {
            _tenant = tenantAccessor.Tenant ?? throw new ArgumentNullException(nameof(TenantDto));
        }

        public DbSet<Producto> Products { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedAt = DateTime.UtcNow;
            //            break;
            //        case EntityState.Modified:
            //            entry.Entity.ModifiedAt = DateTime.UtcNow;
            //            break;
            //    }
            //}

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = _tenant.Items["ConnectionString"]?.ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
