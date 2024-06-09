using Microsoft.AspNetCore.Identity;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> UpdateUserForNutritionAsync(CreateNutritionDto createNutritionDto, Guid userId)
        {
            var getUser = userManager.FindByIdAsync(userId.ToString()).Result;

            if (getUser == null)
                return false;

            getUser.Age = createNutritionDto.Age;
            getUser.Weight = createNutritionDto.Weight;
            getUser.Height = createNutritionDto.Height;
            getUser.NutritionGoal = createNutritionDto.NutritionGoal;
            getUser.NutritionDuration = createNutritionDto.NutritionDuration;
            getUser.LactoseInTolerance = createNutritionDto.LactoseInTolerance;
            getUser.GlutenInTolerance = createNutritionDto.GlutenInTolerance;
            getUser.Vegan = createNutritionDto.Vegan;

            var result = await userManager.UpdateAsync(getUser);
            
            if(result.Errors?.Count() > 0)
                return false;

            return true;
        }

        public async Task<bool> UpdateUserForWorkoutAsync(CreateWorkoutDto createWorkoutDto, Guid userId)
        {
            var getUser = userManager.FindByIdAsync(userId.ToString()).Result;

            if (getUser == null)
                return false;


            getUser.Age = createWorkoutDto.Age;
            getUser.Weight = createWorkoutDto.Weight;
            getUser.Height = createWorkoutDto.Height;
            getUser.WorkoutLevel = createWorkoutDto.WorkoutLevel;
            getUser.WorkoutType = createWorkoutDto.WorkoutType;
            getUser.WorkoutDayCount = createWorkoutDto.WorkoutDayCount;
            getUser.WorkoutDuration = createWorkoutDto.WorkoutDuration;

            var result = await userManager.UpdateAsync(getUser);

            if (result.Errors?.Count() > 0)
                return false;

            return true;
        }
    }
}
