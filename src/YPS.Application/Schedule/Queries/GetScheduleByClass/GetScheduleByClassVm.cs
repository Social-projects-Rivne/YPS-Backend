using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Schedule.Query.GetScheduleByClass
{
    public class GetScheduleByClassVm
    {
        public string DayName { get; set; }
        public string Date { get; set; }
        public ICollection<ScheduleByClassDto> Items { get; set; }
    }
}
