using AppWeb.Models;

namespace AppWeb.DataAccess.Context
{
    public interface ITenantAccessor<T> where T : TenantDto
    {
        public T? Tenant { get; init; }
    }
}
