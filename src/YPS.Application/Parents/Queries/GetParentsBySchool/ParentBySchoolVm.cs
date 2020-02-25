using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Parents.GetParentsBySchool
{
    public class ParentBySchoolVm : IMapFrom<Parent>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WorkInfo { get; set; }
        public List<string> Children { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Parent, ParentBySchoolVm>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.User.Surname))
                .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.User.MiddleName))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(x => x.Children, opt => opt.MapFrom(x => x.ParentToPupils.Select(y => y.PupilOf.User.FirstName + " " + y.PupilOf.User.Surname + " " + y.PupilOf.User.MiddleName
                          + " Class:" + y.PupilOf.ClassOf.Number.ToString() + "-" + y.PupilOf.ClassOf.Character + "\n")));
                
        }
    }
}
