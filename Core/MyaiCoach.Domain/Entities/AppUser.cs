using Microsoft.AspNetCore.Identity;
using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NameSureName { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public WorkoutLevel? WorkoutLevel { get; set; }
        public WorkoutType? WorkoutType { get; set; }
        public int? WorkoutDuration { get; set; }
        public int? WorkoutDayCount { get; set; }
        public NutritionGoal? NutritionGoal { get; set; }
        public int? NutritionDuration { get; set; }
        public bool? LactoseInTolerance { get; set; }
        public bool? GlutenInTolerance { get; set; }
        public bool? Vegan { get; set; }

        public ICollection<WorkoutDay> WorkoutDays { get; set; }
        public ICollection<NutritionDay> NutritionDays { get; set; }

    }
}
