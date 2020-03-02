using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.SchoolRequests.Queries.GetUnviewedSchoolRequests
{
    public class SchoolRequestVm : IMapFrom<SchoolRequest>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumb { get; set; }
    }
}
