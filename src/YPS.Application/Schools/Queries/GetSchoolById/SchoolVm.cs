using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Schools.Queries.GetSchoolById
{
    public sealed class SchoolVm : IMapFrom<School>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string RegistrationLink { get; set; }

        public uint Pupils { get; set; }
        public uint Teachers { get; set; }
        public uint Parents { get; set; }
        public uint Auditoriums { get; set; }
        public uint Disciplines { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<School, SchoolVm>()
                .ForMember(x => x.Pupils, opt => opt.MapFrom(s => s.Users.Where(x => x.Role.Name == "pupil").Count()))
                .ForMember(x => x.Teachers, opt => opt.MapFrom(s => s.Users.Where(x => x.Role.Name == "teacher" || x.Role.Name == "head-asistant").Count()))
                .ForMember(x => x.Parents, opt => opt.MapFrom(s => s.Users.Where(x => x.Role.Name == "parent").Count()))
                .ForMember(x => x.Auditoriums, opt => opt.MapFrom(s => s.Auditoriums.Count))
                .ForMember(x => x.Disciplines, opt => opt.MapFrom(s => s.Disciplines.Count));
        }
    }
}
