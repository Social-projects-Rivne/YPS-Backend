using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.Queries.GetPupilsByClass
{
    public class PupilByClassVm : IMapFrom<Pupil>
    {
        public long Id { get; set; }
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pupil, PupilByClassVm>()
                .ForMember(
                    p => p.FullName, 
                    opt => opt.MapFrom(
                        p => p.User.FirstName + " " + p.User.Surname + " " + p.User.MiddleName
                    )
                );
        }
    }
}
