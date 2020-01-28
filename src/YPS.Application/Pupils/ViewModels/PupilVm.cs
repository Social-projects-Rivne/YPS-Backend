using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Interfaces.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.ViewModels
{
    public class PupilVm : IMapFrom<User>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
