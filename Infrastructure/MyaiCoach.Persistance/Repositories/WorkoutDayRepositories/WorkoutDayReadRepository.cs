using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Repositories.WorkoutDayRepositories;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Repositories.WorkoutDayRepositories
{
    public class WorkoutDayReadRepository : ReadRepository<WorkoutDay>, IWorkoutDayReadRepository
    {
        public WorkoutDayReadRepository(DbContext dbContext, bool tracking = true) : base(dbContext, tracking)
        {
        }
    }
}
