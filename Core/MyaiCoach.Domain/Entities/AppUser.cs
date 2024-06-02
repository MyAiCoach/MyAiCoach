using Microsoft.AspNetCore.Identity;
using MyaiCoach.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string NameSureName { get; set; }

        public ICollection<WorkoutDay> WorkoutDays { get; set; }

    }
}
