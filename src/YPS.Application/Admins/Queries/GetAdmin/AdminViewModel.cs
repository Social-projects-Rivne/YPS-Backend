using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Admins.Queries.GetAdmin
{
    public class AdminViewModel : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string DateOfBirth { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, AdminViewModel>()
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.DateOfBirth.ToString("yyyy-MM-dd")));
        }
    }
}
