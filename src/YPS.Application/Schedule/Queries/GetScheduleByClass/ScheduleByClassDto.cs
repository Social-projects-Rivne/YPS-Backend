using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Schedule.Query.GetScheduleByClass
{
    public class ScheduleByClassDto : IMapFrom<Lesson>
    {
        public string LessonNumber { get; set; }
        public string Discipline { get; set; }
        public long AuditoriumNumber { get; set; }
        public string AuditoriumName { get; set; }
        public string LessonTimeGap { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lesson, ScheduleByClassDto>()
                .ForMember(x => x.LessonNumber, opt => opt.MapFrom(x => x.LessonNumber))
                .ForMember(x => x.Discipline, opt => opt.MapFrom(x => x.Discipline.Name))
                .ForMember(x => x.AuditoriumName, opt => opt.MapFrom(x => x.Auditorium.Name))
                .ForMember(x => x.AuditoriumNumber, opt => opt.MapFrom(x => x.Auditorium.Number))
                .ForMember(x => x.LessonTimeGap, opt => opt.MapFrom(x => x.LessonTimeGap));
        }
    }
}
