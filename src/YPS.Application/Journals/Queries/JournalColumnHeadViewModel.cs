using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Journals.Queries
{
    public class JournalColumnHeadViewModel : IMapFrom<Lesson>
    {
        public string Date { get; set; }
        public ushort LessonNumber { get; set; }
        public string Topic { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Lesson, JournalColumnHeadViewModel>()
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.LessonDate.ToString("dd.MM.yyyy")))
                .ForMember(x => x.Topic, opt => opt.MapFrom(x => x.JournalColumn.Topic));
        }
    }
}
