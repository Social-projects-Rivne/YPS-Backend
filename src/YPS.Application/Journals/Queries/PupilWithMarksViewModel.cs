using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Journals.Queries
{
    public class PupilWithMarksViewModel : IMapFrom<Pupil>
    {
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pupil, PupilWithMarksViewModel>()
                .ForMember(
                    p => p.FullName,
                    opt => opt.MapFrom(
                        p => p.User.Surname + " " + p.User.FirstName 
                    )
                );
        }
    }
}
