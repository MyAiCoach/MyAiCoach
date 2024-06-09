using MyaiCoach.Domain.Dtos.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Services
{
    public interface IUserService
    {
        public Task<bool> UpdateUserForWorkoutAsync(CreateWorkoutDto createWorkoutDto, Guid userId);
        public Task<bool> UpdateUserForNutritionAsync(CreateNutritionDto createNutritionDto, Guid userId);
    }
}
