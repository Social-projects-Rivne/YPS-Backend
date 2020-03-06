using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Days.Queries.GetAllDays
{
    public sealed class DayViewModel : IMapFrom<Day>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
