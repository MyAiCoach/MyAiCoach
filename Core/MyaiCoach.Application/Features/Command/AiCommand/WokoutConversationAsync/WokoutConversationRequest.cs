﻿using MediatR;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class WokoutConversationRequest : IRequest<WokoutConversationResponse>
    {
        public CreateWorkoutDto? CreateWorkoutDto { get; set; }
    }
}   