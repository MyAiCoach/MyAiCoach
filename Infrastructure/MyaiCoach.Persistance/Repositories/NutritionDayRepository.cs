using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Repositories;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Persistance.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Repositories
{
    public class NutritionDayRepository : BaseRepository<NutritionDay>,INutritionDayRepository
    {
        public NutritionDayRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
