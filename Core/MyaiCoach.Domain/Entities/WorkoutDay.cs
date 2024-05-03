using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Enums;

namespace MyaiCoach.Domain.Entities
{
    public class WorkoutDay : BaseEntity
    {
        public Days Days { get; set; }
        public Guid WorkoutSessionId { get; set; }
        public Guid AppUserId { get; set; }
        public DoesItWorks DoesItWorks { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<WorkoutSession> WorkoutSessions { get; set; }
    }
}
