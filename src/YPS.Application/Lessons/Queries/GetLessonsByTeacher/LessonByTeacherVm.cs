using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Lessons.Queries.GetLessonsByTeacher
{
    public class LessonByTeacherVm : IMapFrom<Lesson>
    {
        public ushort LessonNumber { get; set; }
        public string LessonDate { get; set; }
        public string LessonTimeGap { get; set; }
        public string Auditorium { get; set; }
        public string Day { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lesson, LessonByTeacherVm>()
                .ForMember(e => e.LessonDate, opt => opt.MapFrom(e => e.LessonDate.ToString("dd-MM")))
                .ForMember(e => e.Auditorium, opt => opt.MapFrom(e => e.Auditorium.Number))
                .ForMember(e => e.Day, opt => opt.MapFrom(e => e.Day.Name));
        }
    }
}
