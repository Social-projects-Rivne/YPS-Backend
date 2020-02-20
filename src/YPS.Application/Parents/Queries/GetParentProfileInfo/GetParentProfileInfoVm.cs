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
        public string ParentFullName { get; set; }
   
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Parent, GetParentProfileInfoVm>() 
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
            .ForMember(x => x.ParentFullName, opt => opt.MapFrom(x => $"{x.User.FirstName} {x.User.Surname} {x.User.MiddleName}"));
        }
    }
}
