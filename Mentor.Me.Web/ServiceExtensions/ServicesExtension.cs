using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Implementations;
using Mentor.Me.Domain.Services.Interfaces;
using Assignment = Mentor.Me.Data.Entities.Assignment;

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
            services.AddTransient<IRepository<Assignment>, Repository<Assignment>>();
            services.AddTransient<IRepository<Chat>, Repository<Chat>>();
            services.AddTransient<IRepository<Message>, Repository<Message>>();

            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IDealService, DealService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPropositionService, PropositionService>();
            services.AddTransient<IGoogleCalendarService, GoogleCalendarService>();

            services.AddTransient<IApplyRequestService, ApplyRequestService>();
        }
    }
}
