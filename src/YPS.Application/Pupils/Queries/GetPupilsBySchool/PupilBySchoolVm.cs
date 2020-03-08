using System;
using System.Linq;
using AutoMapper;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.Queries.GetPupilsBySchool
{
    public class PupilBySchoolVm : IMapFrom<Pupil>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string ClassName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pupil, PupilBySchoolVm>()
                .ForMember(x=>x.FirstName , opt=>opt.MapFrom(x=>x.User.FirstName))
                .ForMember(x=>x.Surname, opt=>opt.MapFrom(x=>x.User.Surname))
                .ForMember(x=>x.MiddleName, opt=>opt.MapFrom(x=>x.User.MiddleName))
                .ForMember(x=>x.PhoneNumber, opt=>opt.MapFrom(x=>x.User.PhoneNumber))
                .ForMember(x=>x.Email, opt=>opt.MapFrom(x=>x.User.Email))
                .ForMember(x=>x.DateOfBirth, opt=>opt.MapFrom(x=>x.User.DateOfBirth))
                .ForMember(x=>x.Id,opt=>opt.MapFrom(x=>x.User.Id))
                .ForMember(x=>x.ClassName, opt=>opt.MapFrom(x=>x.ClassToPupils.First().Class.Number+"-" + x.ClassToPupils.First().Class.Character));
        }
    }
}
