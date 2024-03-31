using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class WorkoutDay : BaseEntity
    {
        public Days Days { get; set; }

        public ICollection<WorkoutSession> MyProperty { get; set; }

        public AppUser AppUser { get; set; }
    }
}
