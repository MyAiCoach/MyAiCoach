using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Dtos.NutritionDtos
{
    public class FoodViewDto
    {
        public string Name { get; set; }
        public decimal Carbonhydrate { get; set; }
        public decimal Protein {  get; set; }
        public decimal Calory {  get; set; }
        public string Description { get; set; }

    }
}
