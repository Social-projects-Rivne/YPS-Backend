using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsBySchool
{
    public class UpcomingEventVm : IMapFrom<UpcomingEvent>
    {
        public string SchoolName { get; set; }
        public DateTime TimeOfCreating { get; set; }
        public string TeacherFullName { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpcomingEvent, UpcomingEventVm>()
                .ForMember(u => u.TeacherFullName, opt => opt.MapFrom(s => s.Teacher.User.FirstName + " " + s.Teacher.User.Surname))
                .ForMember(u => u.SchoolName, opt => opt.MapFrom(s => s.School.ShortName));
        }
    }
}
