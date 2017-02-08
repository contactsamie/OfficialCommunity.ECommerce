using Hangfire.Dashboard;

namespace OfficialCommunity.ECommerce.Hub.Infrastructure
{
    internal class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = ((AspNetCoreDashboardContext)context).HttpContext;
            return httpContext.User.Identity.IsAuthenticated;
        }
    }
}