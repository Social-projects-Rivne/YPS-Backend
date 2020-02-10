using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Pupils.Query.GetAllPupils
{
    public class PupilDto : IMapFrom<Pupil>
    {
        public long UserId { get; set; }
        public  User User { get; set; }

        public long ClassId { get; set; }
        public  Class ClassOf { get; set; }
    }
}
