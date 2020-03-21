using System;
using System.Linq;
using AutoMapper;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.Queries.GetPupilsBySchool
{
    public class PupilBySchoolVm : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string ClassName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, PupilBySchoolVm>()
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.DateOfBirth.ToString("MM.dd.yyyy")))
                .ForMember(
                    x => x.ClassName,
                    opt => opt.MapFrom(
                        x => x.Pupil.ClassToPupils
                                .Select(z => z.Class)
                                .First(z => z.YearFrom == DateTime.Now.Year || z.YearTo == DateTime.Now.Year).Number
                            + " - "
                            + x.Pupil.ClassToPupils
                                .Select(z => z.Class)
                                .First(z => z.YearFrom == DateTime.Now.Year || z.YearTo == DateTime.Now.Year).Character
                    )
                );
        }
    }
}
