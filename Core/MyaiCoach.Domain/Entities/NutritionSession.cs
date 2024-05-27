using MyaiCoach.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Entities
{
    public class NutritionSession : BaseEntity
    {
        public Guid FoodId{ get; set; }
        public Guid GramId { get; set; }
        public Guid NutritionDayId { get; set; }

        public virtual Food Fodd { get; set; }
        public virtual Gram Gram { get; set; }
        public virtual ICollection<NutritionDay> NutritionDays { get; set;}

    }
}
