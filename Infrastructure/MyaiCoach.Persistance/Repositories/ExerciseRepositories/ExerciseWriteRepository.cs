using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Repositories.ExerciseRepositories;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Repositories.ExerciseRepositories
{
    public class ExerciseWriteRepository : WriteRepository<Exercise>, IExerciseWriteRepository
    {
        public ExerciseWriteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
