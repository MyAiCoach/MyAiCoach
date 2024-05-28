using MyaiCoach.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Services
{
    public interface IUserNutritionService
    {

        Task<bool> SaveNutritionAsync(Guid userId, List<DietProgramViewDto> input);
        
        Task<List<DietProgramViewDto>> GetNutritionProgramAsync(Guid userId);
    }
}
