using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Lessons.Query.GetLessonsByClass
{
    public class GetLessonsByClassVm
    {
        public string DayName { get; set; }
        public string Date { get; set; }
        public ICollection<LessonByClassDto> Items { get; set; }
    }
}
