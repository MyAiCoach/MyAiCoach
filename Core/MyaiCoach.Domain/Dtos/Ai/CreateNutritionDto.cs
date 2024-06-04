
using MyaiCoach.Domain.Enums;

namespace MyaiCoach.Domain.Dtos.Ai
{
    public class CreateNutritionDto
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public NutritionGoal NutritionGoal { get; set; }
        public int NutritionDuration { get; set; }
        public bool LactoseInTolerance { get; set; }
        public bool GlutenInTolerance { get; set; }
        public bool Vegan { get; set; }

    }
}
