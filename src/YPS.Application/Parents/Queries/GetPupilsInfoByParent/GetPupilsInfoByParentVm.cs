using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Parents.Queries.GetPupilsInfoByParent
{
    public class GetPupilsInfoByParentVm : IMapFrom<ParentToPupil>
    {
        
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string ClassName { get; set; }

    public void Mapping(Profile profile)
        {
           profile.CreateMap<ParentToPupil, GetPupilsInfoByParentVm>()
               .ForMember(x => x.Id, opt => opt.MapFrom(x => x.PupilId))
               .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.PupilOf.User.FirstName))
               .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.PupilOf.User.Surname))
               .ForMember(x => x.MiddleName, opt => opt.MapFrom(x => x.PupilOf.User.MiddleName))
               .ForMember(
                   x => x.ClassName,
                   opts => opts.MapFrom(
                       x => x.PupilOf.ClassToPupils.First().Class.Number + " - " + x.PupilOf.ClassToPupils.FirstOrDefault().Class.Character //solo
                   )
               );
       }
    }
}