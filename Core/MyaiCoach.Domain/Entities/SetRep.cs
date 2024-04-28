using MyaiCoach.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class SetRep : BaseEntity
    {
        public string Set { get; set; }
        public string Rep { get; set; }

        public virtual ICollection<WorkoutSession> WorkoutSessions { get; set; }

    }
}
