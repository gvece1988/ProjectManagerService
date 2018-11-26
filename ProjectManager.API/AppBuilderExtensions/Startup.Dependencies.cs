using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Business;
using ProjectManager.DataAccess;

namespace ProjectManager.API.AppBuilderExtensions
{
    /// <summary>
    /// Dependency Registration
    /// </summary>
    public static class DependenciesExtensions
    {
        /// <summary>
        /// Configures the dependencies.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProjectManagerContext, ProjectManagerContext>();
            services.AddTransient<IProjectBL, ProjectBL>();
            services.AddTransient<IUserBL, UserBL>();
            services.AddTransient<ITaskBL, TaskBL>();

            return services;
        }
    }
}