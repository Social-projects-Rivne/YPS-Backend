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
        public long Id { get; set; }
        public string TimeOfCreating { get; set; }
        public string ScheduledDate { get; set; }
        public string TeacherFullName { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string TeacherImageUrl { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpcomingEvent, UpcomingEventVm>()
                .ForMember(u => u.TimeOfCreating, opt => opt.MapFrom(s => s.TimeOfCreation.ToString("dd.MM.yyyy")))
                .ForMember(u => u.ScheduledDate, opt => opt.MapFrom(s => s.ScheduledDate.ToString("dd.MM.yyyy")))
                .ForMember(u => u.TeacherFullName, opt => opt.MapFrom(s => s.Teacher.User.FirstName + " " + s.Teacher.User.Surname))
                .ForMember(u => u.TeacherImageUrl, opt => opt.MapFrom(s => s.Teacher.User.ImageUrl));
        }
    }
}
