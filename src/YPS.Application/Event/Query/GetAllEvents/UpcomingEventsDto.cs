using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Event.Query.GetAllEvents
{
    public class UpcomingEventsDto : IMapFrom<UpcomingEvent>
    {
        public long? ClassId { get; set; }

        public long SchoolId { get; set; }

        public DateTime TimeOfCerate { get; set; }

        public long TeacherId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public Domain.Entities.School School { get; set; }
    }
}
