using MyaiCoach.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class Gram:BaseEntity
    {
        public int Amount { get; set; }
        public string Type { get; set; }

        public virtual ICollection<NutritionSession> NutritionSessions { get; set; }

    }
}
