using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Queries.GetTeachersByDiscipline
{
    public class TeachersByDisciplineVm : IMapFrom<Teacher>
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeachersByDisciplineVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.Surname + " " + x.User.MiddleName));
        }
    }
}
