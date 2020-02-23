using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Parents.ViewModels
{
    public class GetParentProfileInfoVm : IMapFrom<Parent>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string SchoolName { get; set; }
        public string DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public string Workinfo { get; set; }
   
    public void Mapping(Profile profile)
    {
         profile.CreateMap<Parent, GetParentProfileInfoVm>()
             .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
             .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
             .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
             .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.User.Surname))
             .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.User.MiddleName))
             .ForMember(x => x.SchoolName, opt => opt.MapFrom(x => x.User.School.ShortName))
             .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.User.DateOfBirth.ToString("dd-MM-yyyy")))
             .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.User.ImageUrl))
             .ForMember(x => x.Workinfo, opt => opt.MapFrom(x => x.WorkInfo));
        }
    }
}
