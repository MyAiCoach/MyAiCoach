using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.ExerciseDtos;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyaiCoach.Persistance.Utils
{
    public class ParseAIOutput
    {

        public static List<ProgramViewDto> Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), "Input cannot be null or empty");

            var programs = new List<ProgramViewDto>();

            //todo : codes here

            return programs;
        }

    }
}
