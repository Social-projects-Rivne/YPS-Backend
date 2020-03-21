using System;
using System.Linq;
using AutoMapper;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Queries.GetTeachersBySchool
{
    public class TeacherBySchoolVm : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public string DateOfBirth { get; set; }
        public string ClassName { get; set; }
   
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, TeacherBySchoolVm>()
                .ForMember(x => x.Degree, opt => opt.MapFrom(x => x.Teacher.Degree))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.DateOfBirth.ToString("MM.dd.yyyy")))
                .ForMember(
                    x => x.ClassName, 
                    opts => opts.MapFrom(
                        x => x.Teacher.Classes
                                .First(z => z.YearFrom == DateTime.Now.Year || z.YearTo == DateTime.Now.Year).Number
                            + " - "
                            + x.Teacher.Classes
                                .First(z => z.YearFrom == DateTime.Now.Year || z.YearTo == DateTime.Now.Year).Character
                    )
                );
        }
    }
}

