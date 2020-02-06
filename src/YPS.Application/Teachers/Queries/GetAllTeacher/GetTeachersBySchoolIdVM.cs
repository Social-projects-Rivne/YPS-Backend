using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Queries.GetTeacher
{
    public class GetTeachersBySchoolIdVM : IMapFrom<GetTeachersBySchoolIdDTO>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Degree { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, GetTeachersBySchoolIdVM>()
            .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.User.Surname))
            .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.User.MiddleName))
            .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Password))
            .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.User.DateOfBirth))
            .ForMember(x => x.Degree, opt => opt.MapFrom(x => x.Degree))
            ;
        }
    }
}
