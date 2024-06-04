using MyaiCoach.Domain.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.NutritionConversationAsync
{
    public class NutritionConversationAsyncResponse
    {
        public IEnumerable<IBaseViewDto> DietProgramViewDtos { get; set; }
    }
}
