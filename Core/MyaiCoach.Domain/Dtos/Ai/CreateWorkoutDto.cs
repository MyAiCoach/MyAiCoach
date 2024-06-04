using MyaiCoach.Domain.Enums;


namespace MyaiCoach.Domain.Dtos.Ai
{
    public class CreateWorkoutDto
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public WorkoutLevel WorkoutLevel { get; set; }
        public WorkoutType WorkoutType { get; set; }

        public int WorkoutDuration { get; set; }
        public int WorkoutDayCount { get; set; }
    }
}
