using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Base;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Services
{
    public interface IAiServices
    {
        Task<IEnumerable<IBaseViewDto>> ConversationAsync(string text, ReqType reqtype);

    }
}
