using MyaiCoach.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public  class  Food:BaseEntity
    {
        public string Name { get; set; }
        public decimal Carbonhydrate { get; set; }
        public decimal Protein { get; set; }
        public decimal Calory {  get; set; }
        public string Description { get; set; }

        public virtual ICollection<NutritionSession> NutritionSessions { get; set; }

    }
}
