namespace AppWeb.Models
{
    public interface ITenantStore<T> where T : TenantDto
    {
        Task<T> GetTenantAsync(string identifier);
    }
}
