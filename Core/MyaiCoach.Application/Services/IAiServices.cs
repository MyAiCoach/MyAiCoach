﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Services
{
    public interface IAiServices
    {
        Task<string> ConversationAsync(string text);
    }
}
