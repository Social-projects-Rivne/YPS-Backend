using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Queries.GetTeacherBySchoolShort
{
    public class GetTeacherBySchoolShortVm : IMapFrom<Teacher>
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, GetTeacherBySchoolShortVm>()
                .ForMember(e => e.FullName, opt => opt.MapFrom(x => x.User.Surname + " " + x.User.FirstName + " " + x.User.MiddleName));
        }
    }
}
