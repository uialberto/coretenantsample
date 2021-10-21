using AppWeb.Helpers;
using AppWeb.Models;

namespace AppWeb.DataAccess.Context
{
    public class TenantAccessor : ITenantAccessor<TenantDto>
    {
        public TenantAccessor(IHttpContextAccessor contextAccessor, IConfiguration config, IWebHostEnvironment env)
        {
            Tenant = contextAccessor.HttpContext?.GetTenant();

            if (Tenant is null && env.IsDevelopment())
            {
                // Nota 👀:
                // Si estamos en modo desarrollo y no hay Tenant, 
                // probablemente es alguna inicialización o creación de migración
                // en modo desarrollo
                Tenant = new TenantDto(-1, "TBD");
                Tenant.Items["ConnectionString"] = config.GetConnectionString("SingleTenant");
            }
        }

        public TenantDto? Tenant { get; init; }
    }
}
