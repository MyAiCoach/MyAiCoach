using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Repositories.WorkoutSessionRepositories;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Repositories.WorkoutSessionRepositories
{
    public class WorkoutSessionWriteRepository : WriteRepository<WorkoutSession>, IWorkoutSessionWriteRepository
    {
        public WorkoutSessionWriteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
