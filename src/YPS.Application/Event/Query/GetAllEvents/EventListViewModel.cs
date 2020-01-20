using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Event.Models;

namespace YPS.Application.Event.Query.GetAllEvents
{
    public sealed class EventListViewModel
    {
        public List<EventDto> Events { get; set; }
    }
}
