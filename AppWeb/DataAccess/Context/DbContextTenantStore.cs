using AppWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace AppWeb.DataAccess.Context
{
    public class DbContextTenantStore : ITenantStore<TenantDto>
    {
        private readonly TenantAdminDbContext _context;
        private readonly IMemoryCache _cache;

        public DbContextTenantStore(TenantAdminDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<TenantDto> GetTenantAsync(string identifier)
        {
            var cacheKey = $"cache_{identifier}";
            var tenant = _cache.Get<TenantDto>(cacheKey);

            if (tenant is null)
            {
                var entity = await _context.Tenants
                    .FirstOrDefaultAsync(q => q.Identifier == identifier)
                        ?? throw new ArgumentException($"identifier no es un tenant válido");

                tenant = new TenantDto(entity.TenantId, entity.Identifier);

                tenant.Items["Name"] = entity.Name;
                tenant.Items["ConnectionString"] = entity.ConnectionString;

                _cache.Set(cacheKey, tenant);
            }

            return tenant;
        }
    }
}
