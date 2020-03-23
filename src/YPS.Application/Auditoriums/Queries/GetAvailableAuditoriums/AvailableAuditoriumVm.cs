using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Auditoriums.Queries.GetAvailableAuditoriums
{
    public class AvailableAuditoriumVm : IMapFrom<Auditorium>
    {
        public long Id { get; set; }
        public long Auditorium { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Auditorium, AvailableAuditoriumVm>()
                .ForMember(c => c.Auditorium, opt => opt.MapFrom(c => c.Number));
        }
    }
}
