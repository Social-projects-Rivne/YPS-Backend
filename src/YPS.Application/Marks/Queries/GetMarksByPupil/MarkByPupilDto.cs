using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Marks.Queries.GetMarksByPupil
{
    public class MarkByPupilDto : IMapFrom<Mark>
    {
        public string Type { get; set; }
        public string Value { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mark, MarkByPupilDto>()
                .ForMember(e => e.Type, opt => opt.MapFrom(x => x.MarkType.Type));
        }
    }
}
