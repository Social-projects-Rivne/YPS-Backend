using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.Queries.GetPupilsBySchoolShort
{
    public sealed class GetPupilsBySchoolShortVm
    {
        public long Id { get; set; }
        public string FullName { get; set; }
    }
}

