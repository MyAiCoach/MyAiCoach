using Microsoft.Extensions.DependencyInjection;
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

            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<ISetRepRepository, SetRepRepository>();
            services.AddScoped<IWorkoutDayRepository, WorkoutDayRepository>();
            services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepository>();
            
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IGramRepository, GramRepository>();
            services.AddScoped<INutritionDayRepository, NutritionDayRepository>();
            services.AddScoped<INutritionSessionRepository, NutritionSessionRepository>();


            services.AddScoped<IUserExerciseService, UserExerciseService>();
            services.AddScoped<IUserNutritionService, UserNutritionService>();


            services.AddScoped<IUserService, UserService>();

        }
    }
}
