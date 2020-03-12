using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Classes.Queries.GetClassByNumber
{
    public class GetClassByNumberVm : IMapFrom<Class>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Class, GetClassByNumberVm>()
                .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Number + "-" + c.Character));
        }
    }
}
