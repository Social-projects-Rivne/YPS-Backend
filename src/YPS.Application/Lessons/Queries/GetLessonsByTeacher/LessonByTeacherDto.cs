using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Lessons.Queries.GetLessonsByTeacher
{
    public class LessonByTeacherDto : IMapFrom<Lesson>
    {
        public long Id { get; set; }
        public ushort LessonNumber { get; set; }
        public string LessonDate { get; set; }
        public string LessonTimeGap { get; set; }
        public string Auditorium { get; set; }
        public long AuditoriumNumber { get; set; }
        public long DisciplineId { get; set; }
        public string Discipline { get; set; }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public long TeacherId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lesson, LessonByTeacherDto>()
                .ForMember(e => e.LessonDate, opt => opt.MapFrom(e => e.LessonDate.ToString("dd.MM.yyyy")))
                .ForMember(e => e.Auditorium, opt => opt.MapFrom(e => e.Auditorium.Name))
                .ForMember(e=>e.AuditoriumNumber, opt=>opt.MapFrom(e =>e.Auditorium.Number))
                .ForMember(e => e.Discipline, opt => opt.MapFrom(e => e.Discipline.Name))
                .ForMember(e => e.ClassName, opt => opt.MapFrom(e => e.Class.Number + " - " + e.Class.Character));
        }
    }
}
