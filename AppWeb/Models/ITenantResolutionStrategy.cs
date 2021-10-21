namespace AppWeb.Models
{
    public interface ITenantResolutionStrategy
    {
        Task<string> GetTenantIdentifierAsync();
    }
}
