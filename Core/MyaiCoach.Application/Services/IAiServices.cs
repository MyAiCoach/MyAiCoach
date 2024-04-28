using MyaiCoach.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Services
{
    public interface IAiServices
    {
        Task<List<ProgramViewDto>> ConversationAsync(string text);
    }
}
