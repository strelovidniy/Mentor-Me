using Mentor.Me.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mentor.Me.Web.ServiceExtensions
{
    public static class DbExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<MentorMeContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:MentorMeDatabase"));
        }
    }
}
