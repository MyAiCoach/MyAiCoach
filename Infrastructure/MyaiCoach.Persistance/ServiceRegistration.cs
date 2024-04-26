﻿using Microsoft.Extensions.DependencyInjection;
using MyaiCoach.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using MyaiCoach.Persistance.Utils;
using MyaiCoach.Persistance.Repositories;
using MyaiCoach.Application.Repositories;
using MyaiCoach.Application.Services;
using MyaiCoach.Persistance.Services;


namespace MyaiCoach.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(option => option.UseNpgsql(GetConnectionString.GetConnection()));

            services.AddScoped<DbContext, ApiContext>();

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ISetRepRepository, SetRepRepository>();
            services.AddScoped<IWorkoutDayRepository, WorkoutDayRepository>();
            services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepository>();
            
            services.AddScoped<IUserExerciseService, UserExerciseService>();

        }
    }
}
