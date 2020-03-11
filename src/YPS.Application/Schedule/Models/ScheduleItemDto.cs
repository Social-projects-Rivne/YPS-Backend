using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Schedule.Models
{
    public class ScheduleItemDto : IMapFrom<Lesson>
    {
        public long Id { get; set; }
        public ushort LessonNumber { get; set; }
        public string LessonDate { get; set; }
        public string Discipline { get; set; }
        public string AuditoriumName { get; set; }
        public long AuditoriumNumber { get; set; }
        public string LessonTimeGap { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lesson, ScheduleItemDto>()
                .ForMember(x => x.LessonDate, opt => opt.MapFrom(x => x.LessonDate.ToString("dd.MM.yyyy")))
                .ForMember(x => x.Discipline, opt => opt.MapFrom(x => x.Discipline.Name))
                .ForMember(x => x.AuditoriumName, opt => opt.MapFrom(x => x.Auditorium.Name))
                .ForMember(x => x.AuditoriumNumber, opt => opt.MapFrom(x => x.Auditorium.Number));
        }
    }
}
