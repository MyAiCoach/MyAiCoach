using Microsoft.EntityFrameworkCore;
using MyaiCoach.Application.Repositories.SetRepRepositories;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Persistance.Repositories.SetRepRepositories
{
    public class SetRepWriteRepository : WriteRepository<SetRep>, ISetRepWriteRepository
    {
        public SetRepWriteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
