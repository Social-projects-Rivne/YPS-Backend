using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using YPS.Application.Event.Query.GetAllEvents;
using YPS.Application.Mapping;
using YPS.Domain.Entities;
using FluentValidation;

namespace YPS.Application.Teachers.Queries.GetTeacher
{
    public class TeachersBySchoolVm : IMapFrom<Teacher>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ClassName { get; set; }
   
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeachersBySchoolVm>()
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.User.Surname))
            .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.User.MiddleName))
            .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.User.DateOfBirth))
            .ForMember(x => x.ClassName, opts => opts.MapFrom(x => x.Classes.First().Number + "-" + x.Classes.First().Character));
        }
    }
}

