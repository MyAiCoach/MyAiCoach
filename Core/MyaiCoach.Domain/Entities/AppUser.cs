using MyaiCoach.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string Name{ get; set; }

        public ICollection<WorkoutDay> WorkoutDays { get; set; }

    }
}
