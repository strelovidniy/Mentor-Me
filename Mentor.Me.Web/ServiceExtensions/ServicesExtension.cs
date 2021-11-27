using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Implementations;
using Mentor.Me.Domain.Services.Interfaces;
﻿using Mentor.Me.Data.Entities;
using Task = Mentor.Me.Data.Entities.Task;

namespace Mentor.Me.Web.ServiceExtensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<ApplyRequest>, Repository<ApplyRequest>>();
            services.AddTransient<IRepository<Deal>, Repository<Deal>>();
            services.AddTransient<IRepository<Proposition>, Repository<Proposition>>();
            services.AddTransient<IRepository<Skill>, Repository<Skill>>();
            services.AddTransient<IRepository<Task>, Repository<Task>>();

            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IPropositionService, PropositionService>();
        }
    }
}
