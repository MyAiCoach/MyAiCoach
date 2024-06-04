using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class WokoutConversationResponse
    {
        public IEnumerable<IBaseViewDto> ProgramViewDtos { get; set; }
    }
}
