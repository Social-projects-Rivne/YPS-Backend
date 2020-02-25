using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Queries.GetTeacher
{
    public class TeacherProfileInfoVM : IMapFrom<Teacher>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public string ImageUrl { get; set; }
        public string DateOfBirth { get; set; }
        public string ClassName { get; set; }
        public string SchoolName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherProfileInfoVM>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.User.Surname))
                .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.User.MiddleName))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.User.ImageUrl))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.User.DateOfBirth.ToString("yyyy-MM-dd")))
                .ForMember(
                    x => x.ClassName,
                    opts => opts.MapFrom(
                        x => x.Classes.First().Number + "-" + x.Classes.First().Character)
                )
                .ForMember(
                    x => x.SchoolName,
                    opt => opt.MapFrom(
                        x => x.User.School.ShortName));
        }
    }
}