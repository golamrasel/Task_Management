
using Common.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using Models.Models.SystemUsers;
using Models.Models.TaskInfo;
using Repository;
using Services;
using Services.Setup;

namespace HousingColonyPOS
{
    public static class DependencyServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
     

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUsersManager, UserManager>();

            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskManager, TaskManager>();
            return services;
        }
    }
}
