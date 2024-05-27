using MyaiCoach.Domain.Dtos.Base;
using MyaiCoach.Domain.Dtos.ExerciseDtos;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Domain.Dtos
{
    public class ProgramViewDto : IBaseViewDto
    {

        public Days Day{ get; set; }
        public List<ExerciseViewDto> Exercises{ get; set; }
        public List<SetRepViewDto> SetReps { get; set; }


    }
}
