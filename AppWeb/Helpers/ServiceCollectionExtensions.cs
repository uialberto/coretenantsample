using AppWeb.Models;

namespace AppWeb.Helpers
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Agrega los servicios (con clase específica)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TenantBuilder<T> AddMultiTenancy<T>(this IServiceCollection services) where T : TenantDto
            => new(services);

        /// <summary>
        /// Agrega los servicios (con clase default)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TenantBuilder<TenantDto> AddMultiTenancy(this IServiceCollection services)
            => new(services);
    }
}
