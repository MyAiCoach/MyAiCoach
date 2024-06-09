using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Enums;

namespace MyaiCoach.Domain.Entities
{
    public class NutritionDay:BaseEntity
    {
        public Days Days { get; set; }  
        public Guid NutritionSessionId { get; set; }
        public Guid AppUserId { get; set; } 

        public DoesItWorks DoesItWorks { get; set; }

        public virtual  AppUser AppUser { get; set; }
        public virtual ICollection<NutritionSession> NutritionSessions { get; set; }


    }
}
