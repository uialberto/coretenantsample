using AppWeb.Models;

namespace AppWeb.Helpers
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Regresa el Tenant actual
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static T? GetTenant<T>(this HttpContext context) where T : TenantDto
        {
            if (!context.Items.ContainsKey(AppConstants.HttpContextTenantKey))
                return null;

            return context.Items[AppConstants.HttpContextTenantKey] as T;
        }

        /// <summary>
        /// Regresa el Tenant actual
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TenantDto? GetTenant(this HttpContext context) => context.GetTenant<TenantDto>();
    }
}
