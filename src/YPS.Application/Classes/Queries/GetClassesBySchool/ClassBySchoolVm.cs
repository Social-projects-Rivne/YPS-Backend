using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Queries.GetClassesBySchool
{
    public class ClassBySchoolVm : IMapFrom<Class>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Class, ClassBySchoolVm>()
                .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Number + "-" + c.Character));
        }
    }
}
