using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Schedule.Queries.GetScheduleForTeacher
{
    public class ScheduleVm
    {
        public string DayName { get; set; }
        public string Date { get; set; }
        public List<ScheduleItemDto> Items { get; set; }
    }
}
