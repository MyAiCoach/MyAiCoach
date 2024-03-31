using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Repositories
{
    public interface IRepository<T> where : class
    {
        DbSet<T> Table{ get; }
    }
}
