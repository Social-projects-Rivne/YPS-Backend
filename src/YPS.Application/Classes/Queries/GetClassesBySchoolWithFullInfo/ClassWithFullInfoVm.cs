using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Queries.GetClassesBySchoolWithFullInfo
{
    public class ClassWithFullInfoVm : IMapFrom<Class>
    {
        public long Id { get; set; }
        public string Character { get; set; }
        public long Number { get; set; }
        public string TeacherFullName { get; set; }
        public int ChildrenCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Class, ClassWithFullInfoVm>()
                .ForMember(c => c.TeacherFullName, opt => opt.MapFrom(c => $"{c.TeacherOf.User.FirstName} {c.TeacherOf.User.Surname} {c.TeacherOf.User.MiddleName}"))
                .ForMember(c => c.ChildrenCount, opt => opt.MapFrom(c => c.Pupils.Count));
        }
    }
}
