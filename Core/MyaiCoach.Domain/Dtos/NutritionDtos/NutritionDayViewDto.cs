using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Dtos.NutritionDtos
{
    public class NutritionDayViewDto
    {
        public Days Days { get; set; }  
        public Guid NutritionSessionId { get; set; }
        public Guid AppUserId { get; set; }
        public DoesItWorks DoesItWorks { get; set; }

    }
}
