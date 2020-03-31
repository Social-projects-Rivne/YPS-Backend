using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Disciplines.Queries.GetDisciplinesByClass
{
    public class DisciplineByClassVm : IMapFrom<ClassToDiscipline>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ClassToDiscipline, DisciplineByClassVm>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Discipline.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Discipline.Name));
        }
    }
}