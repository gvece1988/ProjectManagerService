using Microsoft.AspNetCore.Builder;

namespace ProjectManager.API.AppBuilderExtensions
{
    /// <summary>
    /// Route Extensions
    /// </summary>
    public static class RouteExtensions
    {
        /// <summary>
        /// Configures the routes.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureRoutes(this IApplicationBuilder app)
        {
            return app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "swagger", action = "" });           
            });
        }
    }
}