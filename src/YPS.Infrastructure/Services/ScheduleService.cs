using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YPS.Application.Interfaces;
using YPS.Application.Schedule.Models;
using YPS.Application.Schedule.Queries.GetScheduleForTeacher;

namespace YPS.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        public List<ScheduleVm> MapSchedule(DateTime firstDayOfWeek, List<ScheduleItemDto> items)
        {
            List<ScheduleVm> vm = new List<ScheduleVm>();

            for (int i = 0; i < 7; i++)
            {
                vm.Add(
                    new ScheduleVm
                    {
                        DayName = firstDayOfWeek.DayOfWeek.ToString(),
                        Date = firstDayOfWeek.ToString("MMMM dd"),
                        Items = new List<ScheduleItemDto>()
                    }
                );

                vm.ElementAt(i).Items.AddRange(items.Where(x => x.LessonDate == firstDayOfWeek.ToString("dd.MM.yyyy")));

                firstDayOfWeek = firstDayOfWeek.AddDays(1);
            }

            return vm;
        }
    }
}
