using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Implementations;
using Mentor.Me.Domain.Services.Interfaces;

namespace Mentor.Me.Web.ServiceExtensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Data.Entities.Task>, Repository<Data.Entities.Task>>();

            services.AddTransient<ITaskService, TaskService>();
        }
    }
}
