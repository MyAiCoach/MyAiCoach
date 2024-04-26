using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class WorkoutSession : BaseEntity
    {
        public Guid ExerciseId { get; set; }
        public Guid SetRepId { get; set; }


        public virtual Exercise Exercise { get; set; }
        public virtual SetRep SetRep { get; set; }
    }
}
