using MyaiCoach.Domain.Dtos.NutritionDtos;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Dtos
{
    public class DietProgramViewDto
    {
        public Days Days { get; set; }
        public List<FoodViewDto> Foods { get; set; }
        public List<GramViewDto> Grams { get; set; }

    }
}
