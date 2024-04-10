using Microsoft.Extensions.DependencyInjection;
using MyaiCoach.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyaiCoach.Persistance.Utils;
using MyaiCoach.Application.Repositories.AppUserRepositories;
using MyaiCoach.Persistance.Repositories.AppUserRepositories;
using MyaiCoach.Application.Repositories.ExerciseRepositories;
using MyaiCoach.Persistance.Repositories.ExerciseRepositories;
using MyaiCoach.Application.Repositories.SetRepRepositories;
using MyaiCoach.Persistance.Repositories.SetRepRepositories;
using MyaiCoach.Application.Repositories.WorkoutDayRepositories;
using MyaiCoach.Persistance.Repositories.WorkoutDayRepositories;
using MyaiCoach.Application.Repositories.WorkoutSessionRepositories;
using MyaiCoach.Persistance.Repositories.WorkoutSessionRepositories;

namespace MyaiCoach.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(option => option.UseNpgsql(GetConnectionString.GetConnection()));

            services.AddScoped<IAppUserReadRepository, AppUserReadRepository>();
            services.AddScoped<IAppUserWriteRepository, AppUserWriteRepository>();

            services.AddScoped<IExerciseReadRepository, ExerciseReadRepository>();
            services.AddScoped<IExerciseWriteRepository, ExerciseWriteRepository>();

            services.AddScoped<ISetRepReadRepository, SetRepReadRepository>();
            services.AddScoped<ISetRepWriteRepository, SetRepWriteRepository>();

            services.AddScoped<IWorkoutDayReadRepository, WorkoutDayReadRepository>();
            services.AddScoped<IWorkoutDayWriteRepository, WorkoutDayWriteRepository>();

            services.AddScoped<IWorkoutSessionReadRepository, WorkoutSessionReadRepository>();
            services.AddScoped<IWorkoutSessionWriteRepository, WorkoutSessionWriteRepository>();
        }
    }
}
