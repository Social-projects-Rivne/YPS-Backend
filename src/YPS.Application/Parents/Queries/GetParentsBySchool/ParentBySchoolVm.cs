using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Parents.Queries.GetParentsBySchool
{
    public class ParentBySchoolVm : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WorkInfo { get; set; }
        public string DateOfBirth { get; set; }
        public List<ChildOfParentVm> Children { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, ParentBySchoolVm>()
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.DateOfBirth.ToString("MM.dd.yyyy")))
                .ForMember(x => x.WorkInfo, opt => opt.MapFrom(x => x.Parent.WorkInfo))
                .ForMember(
                    x => x.Children,
                    opt => opt.MapFrom(
                        x => x.Parent.ParentToPupils
                            .Select(y => y.PupilOf)
                            .Select(y => new ChildOfParentVm
                                {
                                    FullName = $"{y.User.Surname} {y.User.FirstName}  {y.User.MiddleName}",
                                    Class = y.ClassToPupils
                                            .Select(z => z.Class)
                                            .First(z => z.YearFrom == DateTime.Now.Year || z.YearTo == DateTime.Now.Year).Number
                                        + " - "
                                        + y.ClassToPupils
                                            .Select(z => z.Class)
                                            .First(z => z.YearFrom == DateTime.Now.Year || z.YearTo == DateTime.Now.Year).Character
                                }
                            )
                        )
                    );
        }
    }
}
