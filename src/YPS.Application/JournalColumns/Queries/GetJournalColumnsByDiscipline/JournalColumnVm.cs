using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.JournalColumns.Queries.GetJournalColumnsByDiscipline
{
    public class JournalColumnVm : IMapFrom<JournalColumn>
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public ushort LessonNumber { get; set; }
        public string Topic { get; set; }
        public string LessonTimeGap { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JournalColumn, JournalColumnVm>()
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Lesson.LessonDate.ToString("dd.MM.yyyy")))
                .ForMember(x => x.LessonTimeGap, opt => opt.MapFrom(x => x.Lesson.LessonTimeGap))
                .ForMember(x => x.LessonNumber, opt => opt.MapFrom(x => x.Lesson.LessonNumber));
        }
    }
}
