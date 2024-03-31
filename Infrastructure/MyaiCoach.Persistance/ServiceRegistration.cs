using Microsoft.Extensions.DependencyInjection;
using MyaiCoach.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyaiCoach.Persistance.Utils;

namespace MyaiCoach.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(option => option.UseNpgsql(GetConnectionString.GetConnection()));
        }
    }
}
