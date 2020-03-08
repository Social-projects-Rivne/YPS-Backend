using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Schedule.Queries.GetScheduleForTeacher
{
    public class ScheduleItemDto : IMapFrom<Lesson>
    {
        public long Id { get; set; }
        public ushort LessonNumber { get; set; }
        public string Disciplene { get; set; }
        public string AuditoriumName { get; set; }
        public long AuditiriumNumber { get; set; }
        public string LessonTimeGap { get; set; }
    }
}
