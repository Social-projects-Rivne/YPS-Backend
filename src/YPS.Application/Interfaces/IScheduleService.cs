using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Schedule.Models;
using YPS.Application.Schedule.Queries.GetScheduleForTeacher;

namespace YPS.Application.Interfaces
{
    public interface IScheduleService
    {
        List<ScheduleVm> MapSchedule(DateTime firstDayOfWeek, List<ScheduleItemDto> items);
    }
}
