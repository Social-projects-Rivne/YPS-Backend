﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Parents.Queries.GetPupilInfoOfParent
{
    public class GetPupilInfoOfParentVm : IMapFrom<ParentToPupil>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string ClassName { get; set; }

    public void Mapping(Profile profile)
    {
            profile.CreateMap<ParentToPupil, GetPupilInfoOfParentVm>()
             .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.PupilOf.User.FirstName))
                .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.PupilOf.User.Surname))
                .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.PupilOf.User.MiddleName))
                .ForMember(
                      x => x.ClassName,
                      opts => opts.MapFrom(
                           x => x.PupilOf.ClassOf.Number + "-" + x.PupilOf.ClassOf.Character
                       )
                   );
        }
    }
}


 
