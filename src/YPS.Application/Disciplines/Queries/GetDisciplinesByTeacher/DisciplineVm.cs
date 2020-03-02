using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher
{
    public class DisciplineVm : IMapFrom<Discipline>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TeacherToDiscipline, DisciplineVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Discipline.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Discipline.Name));
        }
    }
}
