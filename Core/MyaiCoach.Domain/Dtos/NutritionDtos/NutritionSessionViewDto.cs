using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Dtos.NutritionDtos
{
    public class NutritionSessionViewDto
    {
        public Guid FoodId { get; set; }
        public Guid GramId { get; set; }
        public Guid NutritionDayId { get; set; }
        
    }
}
