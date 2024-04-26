using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class WorkoutDay : BaseEntity
    {
        public Days Days { get; set; }
        public ICollection<Guid> WorkoutSessionsIds { get; set; }
        public Guid AppUserId { get; set; }


        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<WorkoutSession> WorkoutSessions { get; set; }
    }
}
