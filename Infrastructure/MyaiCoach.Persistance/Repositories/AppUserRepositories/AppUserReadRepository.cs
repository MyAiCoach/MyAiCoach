using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Repositories.AppUserRepositories;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Repositories.AppUserRepositories
{
    public class AppUserReadRepository : ReadRepository<AppUser>, IAppUserReadRepository
    {
        public AppUserReadRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
